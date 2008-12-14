using System;
using System.Web.UI;
using Superi.Features;

public partial class Administration_Structure : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnSave.Visible = true;
        phObjects.Visible = false;
        btnSave.Visible = false;
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        
    }

    protected void ntStructure_SelectecIndexChanged(object sender, EventArgs e)
    {
        teText.TextId = int.MinValue;
        aeArticles.ScopeId = int.MinValue;
        if (ntStructure.SelectedIndex > 0)
        {
            Navigation navigation = new Navigation(ntStructure.SelectedIndex);
            if (navigation.ID > 0)
            {
                if (navigation.TextID > 0)
                {
                    teText.TextId = navigation.TextID;
                    btnSave.Visible = true;
                }
                else if (navigation.ArticleScopeID > 0)
                {
                    aeArticles.ScopeId = navigation.ArticleScopeID;
                }
                else if(navigation.SingleMenuPage)
                {
                    phObjects.Visible = true;
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        teText.Save();
        ntStructure.ReloadNodes();
        btnSave.Visible = true;
    }
}
