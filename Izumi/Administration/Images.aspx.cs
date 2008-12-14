using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Superi.Features;

public partial class Administration_Images : Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		bSave.Click += bSave_Click;
		phEdit.Visible = false;
	}

	void bSave_Click(object sender, EventArgs e)
	{
		int imageID;//int.Parse(gwImages.SelectedRow.Cells[0].Text);
		if (int.TryParse(hfImageSelected.Value, out imageID))
		{
			GalleryItem galleryItem = new GalleryItem(imageID);
			string path = Server.MapPath(DefaultValues.TextImagesFolder) + "\\";

			if (fuPicture.HasFile)
			{
                if (!string.IsNullOrEmpty(galleryItem.Picture))
				    File.Delete(path + galleryItem.Picture);

				string extPicture = fuPicture.FileName.Substring(fuPicture.FileName.LastIndexOf("."));
				fuPicture.SaveAs(path + galleryItem.ID + extPicture);

				galleryItem.Picture = galleryItem.ID + extPicture;
			}
			if (fuPreview.HasFile)
			{
                if (!string.IsNullOrEmpty(galleryItem.Preview))
				File.Delete(path + galleryItem.Preview);
				
				string extPreview = fuPreview.FileName.Substring(fuPreview.FileName.LastIndexOf("."));
				fuPreview.SaveAs(path + "_" + galleryItem.ID + extPreview);

				galleryItem.Preview = "_" + galleryItem.ID + extPreview;

			}
			galleryItem.Title = tbTitle.Text;
			galleryItem.SubTitle = tbSubTitle.Text;
            galleryItem.Url = tbUrl.Text;
			galleryItem.Save();
		}
	}

	protected void gwTexts_SelectedIndexChanged(object sender, EventArgs e)
	{
		int textID = int.Parse(gwTexts.SelectedRow.Cells[0].Text);
		hfTextSelected.Value = textID.ToString();
	}

	protected void Page_PreRender(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(hfTextSelected.Value))
			fwImages.Visible = true;
		else
			fwImages.Visible = false;

        gwImages.DataBind();
	}

	protected void gwImages_SelectedIndexChanged(object sender, EventArgs e)
	{
		int imageID = int.Parse(gwImages.SelectedRow.Cells[0].Text);
		hfImageSelected.Value = imageID.ToString();
		if (imageID > 0)
		{
			phEdit.Visible = true;
			GalleryItem galleryItem = new GalleryItem(imageID);
			tbTitle.Text = galleryItem.Title;
			tbSubTitle.Text = galleryItem.SubTitle;
            tbUrl.Text = galleryItem.Url;
		}
	}
	protected void gwImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		if(e.Keys.Count>0)
		{
			int imageID = (int)e.Keys[0];
			GalleryItem galleryItem = new GalleryItem(imageID);
			string path = Server.MapPath(DefaultValues.TextImagesFolder) + "\\";
            if (!string.IsNullOrEmpty(galleryItem.Picture))
                File.Delete(path + galleryItem.Picture);
            if (!string.IsNullOrEmpty(galleryItem.Preview))
                File.Delete(path + galleryItem.Preview);
		}

	}
}
