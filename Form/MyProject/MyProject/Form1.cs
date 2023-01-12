using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using MyLibrary;
using MyProject.localhost;
using System.IO;

//Temel sql komutları formda yapıldı
//Class library tamam
//Web service

namespace MyProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0BJTEAC\SQLEXPRESS; Initial Catalog=OrnekDB; Integrated Security=true");
            //conn.Open();

            //SqlCommand cmd = new SqlCommand("Insert into Kisiler (ID, name, surname, age) values (@p1, @p2, @p3, @p4)", conn);
            //cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            //cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            //cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            //cmd.Parameters.AddWithValue("@p4", textBox4.Text);

            //cmd.ExecuteNonQuery();
            //conn.Close();

            MyClass obj = new MyClass();

            obj.Insert(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text);

            //DataGridView i yeniler
            this.kisilerTableAdapter.Fill(this.ornekDBDataSet.Kisiler);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ornekDBDataSet.Kisiler' table. You can move, or remove it, as needed.
            this.kisilerTableAdapter.Fill(this.ornekDBDataSet.Kisiler);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0BJTEAC\SQLEXPRESS; Initial Catalog=OrnekDB; Integrated Security=true");
            //conn.Open();

            //SqlCommand cmd = new SqlCommand("Delete from Kisiler where ID = @p1", conn);
            //cmd.Parameters.AddWithValue("@p1", textBox1.Text);

            //cmd.ExecuteNonQuery();
            //conn.Close();

            MyWebService obj = new MyWebService();
            obj.Delete(textBox1.Text);
            MessageBox.Show(obj.Print());

            this.kisilerTableAdapter.Fill(this.ornekDBDataSet.Kisiler);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0BJTEAC\SQLEXPRESS; Initial Catalog=OrnekDB; Integrated Security=true");
            conn.Open();

            SqlCommand cmd = new SqlCommand("Update Kisiler set name = @p1, surname = @p2, age = @p3 where ID = @p4", conn);
            cmd.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd.Parameters.AddWithValue("@p2", textBox3.Text);
            cmd.Parameters.AddWithValue("@p3", textBox4.Text);
            cmd.Parameters.AddWithValue("@p4", textBox1.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
            this.kisilerTableAdapter.Fill(this.ornekDBDataSet.Kisiler);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Search kısmı burası
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0BJTEAC\SQLEXPRESS; Initial Catalog=OrnekDB; Integrated Security=true");
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Kisiler where ID = @p7", conn);
            cmd.Parameters.AddWithValue("@p7", textBox1.Text);

            //Yeni bir tablo oluşturdum
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            //DataGridView a yeni bir tablo atmak için bunu kullanırız
            dataGridView1.DataSource = dt;

            conn.Close();
            this.kisilerTableAdapter.Fill(this.ornekDBDataSet.Kisiler);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MyClass obj = new MyClass();

            MessageBox.Show(obj.Topla(Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text)).ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Dosya okunan dosyanın her satırını string dizisi olarak geri döndürür
            //using System.IO ı include lamayı unutmayın
            string[] str = File.ReadAllLines(@"C:\Users\tnrsn\Desktop\Calisma\Ruby\dosya.txt");

            //foreach(var item in str)
            //{
            //    MessageBox.Show(item);
            //}

            MyClass obj = new MyClass();

            obj.Insert(Convert.ToInt32(str[0]), str[1], str[2], str[3]);
            this.kisilerTableAdapter.Fill(this.ornekDBDataSet.Kisiler);
        }
    }
}