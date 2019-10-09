using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Data;

namespace NalogUser.Controls
{
    /// <summary>
    /// Interaction logic for MapControl.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        private System.Windows.Shapes.Path pth;
        private Classes.Core cr;
        public MapControl(Classes.Core Cr)
        {
            InitializeComponent();
            this.cr = Cr;
        }
        private void viewMoreInfoSubject(string id="")
        {
            int id_subject = 0;
            try
            {
                id_subject = Convert.ToInt32(id);
            }
            catch (System.Exception err)
            {
            }
            finally
            {
                DataTable detailInfoSubject = cr.AnalysData.requestMapMoreInfoSubject(id_subject, cr.AnalysData.Var.YearBefore);
                if (detailInfoSubject.Rows.Count > 0 && id_subject != 0)
                {
                    subjectName.Visibility = System.Windows.Visibility.Visible;
                    tabControlMoreInfo.Visibility = System.Windows.Visibility.Visible;
                    //busyed
                    decimal busyed = cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["busyed"]);
                    decimal share_busyed = cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["share_busyed"]);
                    decimal busyed_last = cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["busyed_last"]);
                    decimal busyed_change=cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["busyed_change"]);
                    //total
                    decimal total_population = cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["total_population"]);
                    decimal share_total_population = cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["share_total_population"]);
                    decimal total_population_last = cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["total_population_last"]);
                    decimal total_population_change = cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["total_population_change"]);
                    //unemployed
                    decimal unemployed = cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["unemployed"]);
                    decimal unemployed_last = cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["unemployed_last"]);
                    decimal share_unemployed =cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["share_unemployed"]);
                    decimal unemployed_change=cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["unemployed_change"]);
                    //years
                    string year_last = detailInfoSubject.Rows[0]["year_last"].ToString();
                    string year = detailInfoSubject.Rows[0]["year"].ToString();
                    //totals
                    decimal sum_total_ti_subject_last = cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["sum_total_ti_subject_last"]);
                    decimal sum_total_ti_subject = cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["sum_total_ti_subject"]);
                    decimal share_ti_subject = cr.AnalysData.returnNullDecimal(detailInfoSubject.Rows[0]["share_ti_subject"]);
                    //ti
                    decimal ti = 0;
                    decimal ti_last = 0;
                    //selary
                    decimal salary = 0;
                    decimal salary_last = 0;
                    //
                    string format = "{0:f2}";
                    //Население
                    p_LabeYearAfter.Content = detailInfoSubject.Rows[0]["year_last"].ToString();
                    p_LabeYearBefore.Content = detailInfoSubject.Rows[0]["year"].ToString();
                    p_row00.Content = string.Format(format, total_population_last);
                    p_row01.Content = string.Format(format, total_population) + " (" +
                        string.Format(format, share_total_population * 100) + ")";
                    if (total_population_last > 0)
                    {
                        p_row02.Content = string.Format(format, total_population_change / total_population_last * 100) + "%";
                    }
                    p_row10.Content = string.Format(format, busyed_last);
                    p_row11.Content = string.Format(format, busyed) + " (" +
                        string.Format(format, share_busyed * 100) + ")";
                    if (busyed_last > 0)
                    {
                        p_row12.Content = string.Format(format, busyed_change / busyed_last * 100) + "%";
                    }
                    p_row20.Content = string.Format(format, unemployed_last);
                    p_row21.Content = string.Format(format, unemployed) + " (" +
                        string.Format(format, share_unemployed*100) + ")";
                    if (unemployed_last > 0)
                    {
                        p_row22.Content = string.Format(format, unemployed_change / unemployed_last * 100) + "%";
                    }
                    //
                    format = "{0:f2}";
                    t_LabeYearAfter.Content = year_last;
                    t_LabeYearBefore.Content = year;
                    t_row00.Content = string.Format(format, sum_total_ti_subject_last / 1000);
                    t_row01.Content = string.Format(format, sum_total_ti_subject / 1000);
                    if (sum_total_ti_subject_last > 0)
                    {
                        t_row02.Content = string.Format(format, sum_total_ti_subject / sum_total_ti_subject_last * 100) + "%";
                    }
                    //
                    DataRow[] dRowLev1;
                    dRowLev1 = detailInfoSubject.Select();
                    int index = 0;
                    foreach (DataRow row in dRowLev1)
                    {
                        if (index < 1)
                        {
                            ti = cr.AnalysData.returnNullDecimal(row["ti_1130"]);
                            ti_last = cr.AnalysData.returnNullDecimal(row["ti_1130_last"]);
                            salary = cr.AnalysData.returnNullDecimal(row["salary"]);
                            salary_last = cr.AnalysData.returnNullDecimal(row["salary_last"]);
                        }
                        else
                        {
                            break;
                        }
                        index++;
                    }
                    t_row10.Content = string.Format(format, ti_last / 1000);
                    t_row11.Content = string.Format(format, ti / 1000);
                    if (ti_last > 0)
                    {
                        t_row12.Content = string.Format(format, ((ti_last - ti) / ti_last * 100)) + "%";
                    }
                    t_row20.Content = string.Format(format, salary);
                    t_row21.Content = string.Format(format, salary_last);
                    if (salary_last > 0)
                    {
                        t_row22.Content = string.Format(format, ((salary_last - salary) / salary_last * 100)) + "%";
                    }
                    //
                    subjectName.Content = detailInfoSubject.Rows[0]["subject_name"].ToString() +", относительно " + detailInfoSubject.Rows[0]["district_name"].ToString();
                }
                else
                {
                    MessageBox.Show("Нельзя запросить дополнительную информацию: субъект входит в состав другого.\nОтдельную информацию Вы можете получить с помощью конструтора отчетов.");
                }
            }
        }

        private void MouseLeftButtonDownPath(object sender, MouseButtonEventArgs e)
        {
            object obj;
            try
            {
                pth = sender as Path;
            }
            catch (System.Exception err)
            {
            }
            finally
            {
                if (e.ClickCount == 1)
                {
                    if (!string.IsNullOrEmpty(pth.Uid))
                    {
                        //obj = e.GetPosition(pth.Parent as UIElement);
                        e.Handled = true;
                        //pth = (System.Windows.Shapes.Path)obj;
                        obj = pth;
                        viewMoreInfoSubject(pth.Uid);
                    }
                }
                else
                {
                }
            }
        }
    }
}
