using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusteriCariPortal
{
    public partial class AnaSayfa : System.Web.UI.Page
    {
        SqlConnection connBizim;
        SqlConnection conn;
        SqlDataAdapter adpVeri;
        DataTable tblVeri, dt;





        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglanti"].ConnectionString);
            connBizim = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiBizim"].ConnectionString);
            #region limit bilgileri geliyor
            adpVeri = new SqlDataAdapter("SELECT TOP (1) KAYITTARIH,MUSTERIAD ,CONVERT(VARCHAR(50), CAST(DBSOFFLINE as MONEY),1),CONVERT(VARCHAR(50), CAST(DBSONLINE as MONEY),1),CONVERT(VARCHAR(50), CAST(KALANLIMIT as MONEY), 1),[DURUM]= CASE WHEN DBSONLINE>0 THEN CASE WHEN (DBSONLINE*0.1)>KALANLIMIT THEN 'RİSKLİ' ELSE 'NORMAL' END ELSE CASE WHEN (DBSOFFLINE*0.1)>KALANLIMIT THEN 'RİSKLİ' ELSE 'NORMAL' END END,CONVERT(VARCHAR(50), CAST(ALISLAR as MONEY), 1),CL.DSPSENDEMAILADDR,CONVERT(VARCHAR(50), CAST(BAKIYE as MONEY), 1) FROM RESELLER_LIMIT RL LEFT OUTER JOIN BEKEN2010.dbo.LG_316_CLCARD CL ON CL.CODE=RL.MUSTERIKOD WHERE MUSTERIKOD='" + Session["CariKod"].ToString() + "' ORDER BY KAYITTARIH DESC", connBizim);
            tblVeri = new DataTable();
            adpVeri.Fill(tblVeri);
            foreach (DataRow item in tblVeri.Rows)
            {
                txtBakiye.Text = item[8].ToString();
                if (item[2].ToString() != "0.00")
                { txtLimit.Text = item[2].ToString(); }
                else
                { txtLimit.Text = item[3].ToString(); }
                txtAlim.Text = item[6].ToString();
                txtKalanLimit.Text = item[4].ToString();
            }
            #endregion

                BindData();

        }
        protected void BindData()
        {
            SqlCommand cmd = new SqlCommand("SELECT PLAKA,RESIMYOL FROM BS_PLAKA WHERE CARIKOD='" + Session[0].ToString() + "'", connBizim);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            dt = new DataTable();
            sda.Fill(dt);
            PlakaList.DataSource = dt;
            PlakaList.DataBind();





        }

        protected void PlakaList_ItemDataBound(object sender, DataListItemEventArgs e)
        {

          
        }

        protected void PlakaList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "liste")
            {
                int index = e.Item.ItemIndex;
                //  index = PlakaList.SelectedIndex;

                Session["plaka"] = dt.Rows[index][0].ToString();

                string navigateURL = "Plaka_Detay.aspx";
                string target = "_blank";
                string windowProperties = "status=yes, menubar=yes, toolbar=yes";
                string scriptText = "window.open('" + navigateURL + "','" + target + "','" + windowProperties + "')";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "eşsizAnahtar", scriptText, true);
            }   
             
        }



        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                (e.Item.FindControl("lblPlaka") as Label).Text = (e.Item.ItemIndex + 1).ToString();
            }
        }




    }
}