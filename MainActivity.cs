using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace test2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView students;
        ArrayAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            students = FindViewById<ListView>(Resource.Id.students);
            var add = FindViewById<Button>(Resource.Id.add);
            var search = FindViewById<SearchView>(Resource.Id.search);
            adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, Student.students);

            add.Click += delegate
            {

                Intent intent = new Intent(this, typeof(Reg));
                StartActivity(intent);
            };
            search.QueryTextChange += (s, e) =>
            {
                adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, Student.students);
                students.Adapter = adapter;
                adapter.Filter.InvokeFilter(e.NewText);
            };
            students.ItemClick += (s, e) => {

                Intent intent = new Intent(this, typeof(Gpa));
                StartActivity(intent);
            };
        }
           
       

        protected override void OnRestart()
        {
            base.OnRestart();
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, Student.students);
            students.Adapter = adapter;
        }
    }
}