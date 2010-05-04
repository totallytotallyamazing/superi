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
    private object currentSelectedItem;

    public Home()
    {
      InitializeComponent();
      ClipsCover.ItemsSource = getItems();
      ClipsCover.SelectedItemChanged += new ControlLibrary.SelectedItemChangedEvent(ClipsCover_SelectedItemChanged);
    }       

    // Executes when the user navigates to this page.
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
    }

    public static IEnumerable<ClipData> getItems()
    {
      return new ClipData[]
      {
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик1"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик2"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик3"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик4"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик5"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик6"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик7"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик8"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик9"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик10"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик11"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик12"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик13"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик14"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик15"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик16"},
        new ClipData(){ ImageUrl=@"/Tina;Component/Assets/playerBg.jpg", PreviewUrl=@"http://tinakarol.ua/Clips/011.wmv", Title="Ключик17"},
      
      };


    }

    private void ClipsCover_SelectedItemChanged(ControlLibrary.CoverFlowEventArgs e)
    {
      if (e == null || !e.MouseClick) return;

      ClipData item = e.Item as ClipData;
      if (item == null) return;

      if (currentSelectedItem == e.Item)
        PlayNewItem(item.PreviewUrl);
      currentSelectedItem = e.Item;
    }

    private void PlayNewItem(string p)
    {
      player.SetSource(p);
      player.Play();
    }   

  }



  public class ClipData
  {
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string PreviewUrl { get; set; }
  }

}