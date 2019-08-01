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
    [Activity(Label = "Reg")]
    public class Reg : Activity
    {
        List<string> Ids;
        EditText id;
        string Id;
        AlertDialog alert;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Registration);

            var fName = FindViewById<EditText>(Resource.Id.fName);
            var lName = FindViewById<EditText>(Resource.Id.lName);
            id = FindViewById<EditText>(Resource.Id.id);
            var savebtn = FindViewById<Button>(Resource.Id.savebtn);
            var goback = FindViewById<Button>(Resource.Id.goback);


            Ids = new List<string>();

            savebtn.Click += delegate
            {
                Id = id.Text;


                if (!string.IsNullOrEmpty(fName.Text) && (!string.IsNullOrEmpty(fName.Text) && !string.IsNullOrEmpty(id.Text)))

                {
                    if (!Ids.Contains(Id))
                    {
                        alert = (new AlertDialog.Builder(this)).Create();
                        alert.SetMessage("Are you sure you want to register? ");
                        alert.SetButton("Yes, I'm Sure!", YesButton);
                        alert.SetButton2("No Way!", NoButton);
                        alert.Show();



                    }
                    else { Toast.MakeText(this, $"Sorry, the id  has already been created", ToastLength.Long).Show(); }

                }


                else { Toast.MakeText(this, $"error, please enter all the field", ToastLength.Long).Show(); }
            };

            goback.Click += delegate {
                Finish();
            };
        }

        private void NoButton(object sender, DialogClickEventArgs e)
        {
            alert.Dismiss();
        }

        private void YesButton(object sender, DialogClickEventArgs e)
        {
            var fName = FindViewById<EditText>(Resource.Id.fName);
            var lName = FindViewById<EditText>(Resource.Id.lName);
            Student student = new Student(fName.Text, lName.Text, Convert.ToInt32(id.Text));
            Student.students.Add(student);
            Ids.Add(Id);
            Toast.MakeText(this, $"you "+fName.Text+" "+lName.Text+" "+"is a student", ToastLength.Long).Show();

            fName.Text = "";
            lName.Text = "";
            id.Text = "";
        }

       
            }
        }
     