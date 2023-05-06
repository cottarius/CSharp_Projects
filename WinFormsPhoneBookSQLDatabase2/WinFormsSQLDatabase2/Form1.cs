using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsSQLDatabase2
{       
    public partial class Form1 : Form
    {
        Database database = new Database();
        int selectedRow;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from birthdaysTable";

            SqlCommand command = new SqlCommand(queryString, database.getConnection());

            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

        }

        private void ReadSingleRow(DataGridView view, IDataRecord record)
        {
            view.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDateTime(2), record.GetString(3));
        }

        public void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("name", "Ф.И.О.");
            dataGridView1.Columns.Add("birthday", "Дата Рождения");
            dataGridView1.Columns.Add("phone", "Телефон");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            database.openConnection();

            var name = textBoxName.Text;
            var birthday = textBoxBirthday.Text;
            var phone = textBoxPhone.Text;

            var queryString = $"insert into birthdaysTable (name, birthday, phone) values ('{name}','{birthday}', '{phone}')";

            SqlCommand command = new SqlCommand(queryString, database.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись усешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBoxName.Text = "";
            textBoxBirthday.Text = "";
            textBoxPhone.Text = "";

            //RefreshDataGrid(dataGridView1);

            database.closeConnection();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }
        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBoxId.Text;
            var name = textBoxNameMofify.Text;
            var birthday = textBoxBirthdayModify.Text;
            var phone = textBoxPhoneModify.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != String.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(id, name, birthday, phone);
            }           
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBoxId.Text = row.Cells[0].Value.ToString();
                textBoxNameMofify.Text = row.Cells[1].Value.ToString();
                textBoxBirthdayModify.Text = row.Cells[2].Value.ToString();
                textBoxPhoneModify.Text = row.Cells[3].Value.ToString();
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            database.openConnection();
            Change();

            var id = dataGridView1.Rows[0].Cells[0].Value.ToString();
            var name = dataGridView1.Rows[0].Cells[1].Value.ToString();
            var birthday = dataGridView1.Rows[0].Cells[2].Value.ToString();
            var phone = dataGridView1.Rows[0].Cells[3].Value.ToString();

            var changeQuery = $"update birthdaysTable set name = '{name}', birthday = '{birthday}', phone = '{phone}' where id = '{id}'";

            var command = new SqlCommand(changeQuery, database.getConnection());
            command.ExecuteNonQuery();
            //RefreshDataGrid(dataGridView1);

            database.closeConnection();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            database.openConnection();
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;

            var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);

            var deleteQuery = $"delete from birthdaysTable where id = '{id}'";

            var command = new SqlCommand(deleteQuery, database.getConnection());
            command.ExecuteNonQuery();
            //RefreshDataGrid(dataGridView1);
            database.closeConnection();
        }
    }
}
