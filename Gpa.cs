using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace test2
{
    [Activity(Label = "Gpa")]
    public class Gpa : Activity
    {
        double Mark1;
        double Mark2;
        double Mark3;
        double Mark4;
        double Mark5;

        EditText mark1;
        EditText mark2;
        EditText mark3;
        EditText mark4;
        EditText mark5;
        Button calgpa;
        TextView gpa;
        Button goback;
        double totalGpa;
        double totalCredit;
        double gpaPoint;
        AlertDialog alert;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.GPACalculator);

            mark1 = FindViewById<EditText>(Resource.Id.mark1);
             mark2 = FindViewById<EditText>(Resource.Id.mark2);
             mark3 = FindViewById<EditText>(Resource.Id.mark3);
             mark4 = FindViewById<EditText>(Resource.Id.mark4);
             mark5 = FindViewById<EditText>(Resource.Id.mark5);
            calgpa = FindViewById<Button>(Resource.Id.gpaCa);
             gpa = FindViewById<TextView>(Resource.Id.gpa);
            goback = FindViewById<Button>(Resource.Id.goBack);

            
            calgpa.Click += delegate {
                int cCredit1 = 4;
                int cCredit2 = 3;
                int cCredit3 = 2;
                int cCredit4 = 3;
                int cCredit5 = 1;
                totalGpa = 0;
                totalCredit = cCredit1 + cCredit2 + cCredit3 + cCredit4 + cCredit5;
                if (!string.IsNullOrEmpty(mark1.Text) && !string.IsNullOrEmpty(mark2.Text) && !string.IsNullOrEmpty(mark3.Text) && !string.IsNullOrEmpty(mark4.Text) && (!string.IsNullOrEmpty(mark5.Text)))
                {

                    Mark1 = Convert.ToDouble(mark1.Text);

                    Mark2 = Convert.ToDouble(mark2.Text);

                    Mark3 = Convert.ToDouble(mark3.Text);

                    Mark4 = Convert.ToDouble(mark4.Text);

                    Mark5 = Convert.ToDouble(mark5.Text);
                    if (Mark1 < 0 || Mark1 > 100 || Mark2 < 0 || Mark2 > 100 || Mark3 < 0 || Mark3 > 100 ||
                        Mark4 < 0 || Mark4 > 100 || Mark5 < 0 || Mark5 > 100)
                    {
                        Toast.MakeText(this, "Error!\nThe grades have to be between 0 and 100", ToastLength.Long).Show();
                    }
                    else
                    {
                        totalGpa = ((Mark1 * cCredit1) + (Mark2 * cCredit2) + (Mark3 * cCredit3) + (Mark4 * cCredit4) + (Mark5 * cCredit5)) / totalCredit;


                        if (totalGpa <= 100 && totalGpa >= 94)
                        {
                            gpaPoint = 4.0;

                        }
                        else if (totalGpa <= 93 && totalGpa >= 87)
                        {
                            gpaPoint = 3.7;
                        }
                        else if (totalGpa <= 86 && totalGpa >= 80)
                        {
                            gpaPoint = 3.5;
                        }
                        else if (totalGpa <= 79 && totalGpa >= 77)
                        {
                            gpaPoint = 3.2;
                        }
                        else if (totalGpa <= 76 && totalGpa >= 73)
                        {
                            gpaPoint = 3.0;
                        }
                        else if (totalGpa <= 72 && totalGpa >= 70)
                        {
                            gpaPoint = 2.7;
                        }
                        else if (totalGpa <= 69 && totalGpa >= 67)
                        {
                            gpaPoint = 2.3;
                        }
                        else if (totalGpa <= 66 && totalGpa >= 63)
                        {
                            gpaPoint = 1.0;
                        }
                        else if (totalGpa <= 62 && totalGpa >= 60)
                        {
                            gpaPoint = 1.7;
                        }
                        else if (totalGpa <= 59 && totalGpa >= 50)
                        {
                            gpaPoint = 1.0;
                        }
                        else if (totalGpa <= 49 && totalGpa >= 0)
                        {
                            gpaPoint = 0.0;
                        }
                        gpa.Text = Convert.ToString(gpaPoint);
                        Toast.MakeText(this, "gpa=" + gpa.Text, ToastLength.Long).Show();
                        if (gpaPoint >= 2.8)
                        {
                            Toast.MakeText(this, "you are eligible for co-op", ToastLength.Long).Show();
                        }
                        else
                        {
                            Toast.MakeText(this, "you are not eligible for co-op", ToastLength.Long).Show();
                        }


                    }
                }

                else
                {

                    
                }
            };
            goback.Click +=  delegate{
                alert = (new AlertDialog.Builder(this)).Create();
                alert.SetMessage("Are you sure you want to register? ");
                alert.SetButton("Yes, I'm Sure!", YesButton);
                alert.SetButton2("No Way!", NoButton);
                alert.Show();
               

            };
        }

        private void NoButton(object sender, DialogClickEventArgs e)
        {
            alert.Dismiss();
        }

        private void YesButton(object sender, DialogClickEventArgs e)
        {
            Student student = new Student(gpaPoint);
            Student.students[0] = student;
            Finish();
        }
    }
}