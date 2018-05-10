using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _16_TextControl
{
    public class SelectionBindTextBox:TextBox
    {


        public int SelectionStartIndex
        {
            get { return (int)GetValue(SelectionStartIndexProperty); }
            set { SetValue(SelectionStartIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectionStartIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectionStartIndexProperty =
            DependencyProperty.Register("SelectionStartIndex", typeof(int), typeof(SelectionBindTextBox), new PropertyMetadata(0));





        public int SelectedLength
        {
            get { return (int)GetValue(SelectedLengthProperty); }
            set { SetValue(SelectedLengthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedLengthProperty =
            DependencyProperty.Register("SelectedLength", typeof(int), typeof(SelectionBindTextBox), new PropertyMetadata(0));





        public string SelectionText
        {
            get { return (string)GetValue(SelectionTextProperty); }
            set { SetValue(SelectionTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectionText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectionTextProperty =
            DependencyProperty.Register("SelectionText", typeof(string), typeof(SelectionBindTextBox), new PropertyMetadata(string.Empty));



        protected override void OnSelectionChanged(RoutedEventArgs e)
        {
            base.OnSelectionChanged(e);
            SelectionStartIndex = SelectionStart;
            SelectedLength = SelectionLength;
            SelectionText = SelectedText;
        }
    }
}
