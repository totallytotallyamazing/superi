using System;
using System.Web.UI;
using Superi.Features;

public partial class Administration_Texts : Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		btnUpdateDescription.Click += btnUpdateDescription_Click;
		phEdit.Visible = false;
	}

	void btnUpdateDescription_Click(object sender, EventArgs e)
	{
		int textID = int.Parse(hfTextSelected.Value);
		if (textID > 0)
		{
			Text text = new Text(textID);
            text.Value = reText.DefaultValue;
            text.TextID = reText.Values.Save();
            text.NameTextId = reName.Values.Save();
            text.Save();
			phEdit.Visible = true;
		}
	}

    //protected void Page_PreRender(object sender, EventArgs e)
    //{ 
    //    int textID = int.Parse(hfTextSelected.Value);
    //    if (textID > 0 && phEdit.Visible)
    //    {
    //        Text text = new Text(textID);
    //        reText.TextID = text.TextID;
    //        reText.DefaultValue = text.Value;
    //        reName.TextID = text.NameTextId;
    //    }
    //}

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		int textID = int.Parse(gwTexts.SelectedRow.Cells[0].Text);
		hfTextSelected.Value = textID.ToString();
		if (textID > 0)
		{
			Text text = new Text(textID);
            reText.TextID = text.TextID;
            reText.DefaultValue = text.Value;
            reName.TextID = text.NameTextId;
            phEdit.Visible = true;
		}
	}
}
