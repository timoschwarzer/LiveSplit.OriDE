using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Linq;
using System.Globalization;

namespace OriMap {
    /// <summary>
    /// Interaktionslogik für OriMap.xaml
    /// </summary>
    public partial class OriMapWindow : Window {
        private TranslateTransform mapTransform;
        private Point contextMenuPosition = new Point(0, 0);
        private Point currentPlayerPosition = new Point(0, 0);

        private List<Marker> markers = new List<Marker>();
        private bool transparencyEnabled = false;
        private bool showMarkerDots = false;

        public delegate void OnChangeTransparencyHandler(bool newTransparency);
        public event OnChangeTransparencyHandler OnChangeTransparency;

        public OriMapWindow(bool transparent = false, Rect windowRect = new Rect()) {
            InitializeComponent();
            mapTransform = new TranslateTransform();
            mapGrid.RenderTransform = mapTransform;

            if (transparent) {
                transparencyEnabled = true;
                WindowStyle = WindowStyle.None;
                AllowsTransparency = true;
                mainGrid.Background = Brushes.Transparent;
            } else {
                mainGrid.OpacityMask = null;
            }

            Left = windowRect.Left;
            Top = windowRect.Top;
            Height = windowRect.Height;
            Width = windowRect.Width;
        }

        public void setPos(System.Drawing.PointF pos) {
            currentPlayerPosition.X = pos.X;
            currentPlayerPosition.Y = pos.Y;
            mapTransform.X = ((-pos.X) * MapCalc.FACTOR_X + MapCalc.TRANSFORM_TO_ORIGIN_X) + mainGrid.ActualWidth / 2;
            mapTransform.Y = ((pos.Y) * MapCalc.FACTOR_Y + MapCalc.TRANSFORM_TO_ORIGIN_Y) + mainGrid.ActualHeight / 2;
            alphaMask.Viewport = new Rect(0, 0, mainGrid.ActualWidth, mainGrid.ActualHeight);

            foreach (Marker marker in markers) {
                if (marker.Split && marker.SplitEnabled && MapCalc.distance(currentPlayerPosition, marker.IngamePosition) < 6) {
                    marker.Triggered = true;
                    marker.SplitEnabled = false;
                    processMarkers();
                }
            }
        }

        private void loadMarkers() {
            markers.Clear();

            if (File.Exists("markers.xml")) {
                XDocument doc = XDocument.Load("markers.xml");
                foreach (XElement element in doc.Element("markers").Elements("marker")) {
                    Marker marker = new OriMap.Marker();
                    marker.Color = Color.FromRgb(
                        byte.Parse(element.Attribute("color_r").Value),
                        byte.Parse(element.Attribute("color_g").Value),
                        byte.Parse(element.Attribute("color_b").Value)
                    );
                    marker.IngamePosition = new Point(
                        double.Parse(element.Attribute("pos_x").Value, CultureInfo.GetCultureInfo("en-US")),
                        double.Parse(element.Attribute("pos_y").Value, CultureInfo.GetCultureInfo("en-US"))
                    );
                    marker.Name = element.Attribute("name").Value;
                    marker.Split = bool.Parse(element.Attribute("split").Value);
                    markers.Add(marker);
                }

                processMarkers();
            }
        }

        private void processMarkers() {
            if (markers.Count > 0)
                markers[0].Split = true;

            int splitStartIndex = 0;
            int currentMarkerIndex = 0;
            foreach (Marker marker in markers) {
                if (marker.Split) {
                    if (marker.Triggered) {
                        splitStartIndex = currentMarkerIndex;
                    } else {
                        marker.SplitEnabled = true;
                        break;
                    }
                } 

                currentMarkerIndex++;
            }

            markersCanvas.Children.Clear();
            bool first = true;
            Point lastPosition = new Point();
            bool isHidden = true;
            currentMarkerIndex = 0;
            bool hideLines = true;
            foreach (Marker marker in markers) {
                if (marker.Removed) continue;

                if (!first && !hideLines) {
                    Line line = new Line();

                    line.StrokeThickness = 2;
                    line.Stroke = Brushes.White;
                    Point newPosition = MapCalc.ingameToMap(marker.IngamePosition);

                    line.X1 = lastPosition.X;
                    line.Y1 = lastPosition.Y;
                    line.X2 = newPosition.X;
                    line.Y2 = newPosition.Y;

                    if (isHidden) {
                        line.Opacity = 0.2;
                    }

                    markersCanvas.Children.Add(line);
                }

                if (currentMarkerIndex == splitStartIndex) {
                    isHidden = false;
                    hideLines = false;
                }

                UIMarker uiMarker = new UIMarker();
                uiMarker.setMarker(marker);
                markersCanvas.Children.Add(uiMarker);

                uiMarker.OnMarkerUpdated += processMarkers;

                if (!first && !showMarkerDots && !(marker.Split && !marker.Triggered && !isHidden) && marker.Name == "") {
                    uiMarker.ellipse.Fill = Brushes.Transparent;
                    uiMarker.ellipse.StrokeThickness = 0;
                    uiMarker.label.Visibility = Visibility.Hidden;
                }

                if (isHidden) {
                    uiMarker.Opacity = 0.2;
                }

                if (marker.Split && !marker.Triggered) {
                    if (!isHidden) {
                        isHidden = true;
                    }
                }

                lastPosition = MapCalc.ingameToMap(marker.IngamePosition);

                currentMarkerIndex++;
                first = false;
            }
        }

        private void saveMarkers() {
            XDocument doc = new XDocument();
            XElement root = new XElement("markers");

            foreach (Marker marker in markers) {
                if (marker.Removed) continue;

                XElement markerElement = new XElement("marker");

                markerElement.Add(new XAttribute("color_r", marker.Color.R.ToString()));
                markerElement.Add(new XAttribute("color_g", marker.Color.G.ToString()));
                markerElement.Add(new XAttribute("color_b", marker.Color.B.ToString()));
                markerElement.Add(new XAttribute("pos_x", marker.IngamePosition.X.ToString(CultureInfo.GetCultureInfo("en-US"))));
                markerElement.Add(new XAttribute("pos_y", marker.IngamePosition.Y.ToString(CultureInfo.GetCultureInfo("en-US"))));
                markerElement.Add(new XAttribute("name", marker.Name));
                markerElement.Add(new XAttribute("split", marker.Split.ToString()));

                root.Add(markerElement);
            }

            doc.Add(root);
            doc.Save("markers.xml");
        }

        public static Point GetMousePosition() {
            System.Drawing.Point point = System.Windows.Forms.Cursor.Position;
            return new Point(point.X, point.Y);
        }

        private void addNewMarkerAtPosition(Point pos) {
            Marker marker = new Marker();
            marker.IngamePosition = pos;
            marker.Color = Colors.White;

            MarkerEditor editor = new MarkerEditor();
            editor.setMarker(marker);
            editor.Owner = this;

            if (editor.ShowDialog() == true) {
                markers.Add(marker);
                processMarkers();
            }
        }

        private void zoomInMenuItem_Click(object sender, RoutedEventArgs e) {
            mapScale.ScaleX *= 1.5;
            mapScale.ScaleY *= 1.5;
        }

        private void zoomOutMenuItem_Click(object sender, RoutedEventArgs e) {
            mapScale.ScaleX /= 1.5;
            mapScale.ScaleY /= 1.5;
        }

        private void resetZoomMenuItem_Click(object sender, RoutedEventArgs e) {
            mapScale.ScaleX = 1;
            mapScale.ScaleY = 1;
        }

        private void mainGrid_ContextMenuOpening(object sender, ContextMenuEventArgs e) {
            contextMenuPosition = MapCalc.mapToIngame(mapGrid.PointFromScreen(GetMousePosition()));
            Console.WriteLine(contextMenuPosition);
        }

        private void addMarkerAtClickPositionMenuItem_Click(object sender, RoutedEventArgs e) {
            addNewMarkerAtPosition(contextMenuPosition);
        }

        private void addMarkerAtPlayerPositionMenuItem_Click(object sender, RoutedEventArgs e) {
            addNewMarkerAtPosition(currentPlayerPosition);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            saveMarkers();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            loadMarkers();
        }

        private void toggleTransparencyMenuButton_Click(object sender, RoutedEventArgs e) {
            OnChangeTransparency?.Invoke(!transparencyEnabled);
        }

        private void resetMarkersMenuItem_Click(object sender, RoutedEventArgs e) {
            foreach (Marker marker in markers) {
                marker.SplitEnabled = false;
                marker.Triggered = false;
            }

            processMarkers();
        }
    }
}
