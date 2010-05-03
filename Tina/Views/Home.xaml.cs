using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tina
{
  public partial class Home : Page
  {
    public Home()
    {
      InitializeComponent();
      this.allVideo.rotatePanel.Rotate += new RotatePanelItemChangedDelegate(rotatePanel_Rotate);
    }

    void rotatePanel_Rotate(object sender, RotatePanelItemChangedEventArgs e)
    {     
      player.SetSource("http://tinakarol.ua/Clips/011.wmv");
      player.Play();     
    }

    // Executes when the user navigates to this page.
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
    }
  
  }
}