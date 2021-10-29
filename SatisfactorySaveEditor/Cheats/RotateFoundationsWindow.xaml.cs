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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SatisfactorySaveEditor.Cheats
{
    /// <summary>
    /// RotateFoundationsWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class RotateFoundationsWindow : Window
    {
        public enum EnumPositionCorrectionSetting
        {
            Nothing,
            Round
        }

        public enum EnumErrorRangeSetting
        {
            Rotation,
            Angle
        }

        public RotateFoundationsWindow()
        {
            InitializeComponent();
        }

        private void ClickSearch(object sender, RoutedEventArgs e)
        {

        }

        private void ClickAutofill(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeRotationZ(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeRotationW(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeAngle(object sender, RoutedEventArgs e)
        {

        }

        private void ClickErrorRangeSettingRotation(object sender, RoutedEventArgs e)
        {

        }

        private void ClickErrorRangeSettingAngle(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeRotationErrorRange(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeAngleErrorRange(object sender, RoutedEventArgs e)
        {

        }

        private void ClickCorrectPositionSettingNothing(object sender, RoutedEventArgs e)
        {

        }

        private void ClickCorrectPositionSettingRound(object sender, RoutedEventArgs e)
        {

        }

        private void ClickDone(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
