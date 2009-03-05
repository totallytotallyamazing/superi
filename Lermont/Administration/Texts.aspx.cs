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
            text.TextID = reText.ResourceId;
		    text.NameTextId = reName.Values.Save();
			text.Save();
			phEdit.Visible = true;
		}
	}

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		int textID = int.Parse(gwTexts.SelectedRow.Cells[0].Text);
		hfTextSelected.Value = textID.ToString();
		if (textID > 0)
		{
			Text text = new Text(textID);
            reText.TextID = text.TextID;
		    reName.TextID = text.NameTextId;
			phEdit.Visible = true;
		}
	}
}