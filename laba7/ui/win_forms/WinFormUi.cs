using laba7.data;
using laba7.data.OOP1lb.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace laba7.ui.win_forms
{
    public partial class WinFormUi : Form, ZheckVeiw
    {
        Controller controller;
        public WinFormUi()
        {
            InitializeComponent();
        }

        public string error { set { MessageBox.Show(value); } }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var a = new Zheck(
                    region: textBox2.Text,
                    name: textBox4.Text,
                    numberHabitians: (double)numericUpDown3.Value,
                    numberOfBuildings: (double)numericUpDown4.Value
                );
                controller.addZheck( a);
            } catch(Exception ex )
            {
                error = "Неверное значение одного из полей "+ex.Message;
            }
        }

        void ZheckVeiw.SetController(Controller _controller)
        {
            controller = _controller;
        }

        void ShowZheckList(List<Zheck> zheckList)
        {
            listBox1.Items.Clear();
            zheckList.ForEach((z) => {
                listBox1.Items.Add(z.Number1+" "+z.Name1);
            });
        }
        void ZheckVeiw.Run(ZheckRepository repo)
        {
           
            repo.updated += (o, z) => { ShowZheckList(z); };
            controller.getZhecks();
            Application.Run(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var n = Int32.Parse(listBox1.SelectedItem?.ToString().Split()[0]);
                Zheck z = new Zheck(
                        region: textBox8.Text,
                        num:n,
                        name: textBox6.Text,
                        numberHabitians: (double)numericUpDown3.Value,
                        numberOfBuildings: (double)numericUpDown4.Value
                    );
                controller.changeZheck(z);
            }
            catch (Exception ex)
            {
                error = "Неверное значение одного из полей "+ex.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1?.SelectedItem != null) controller.removeZheck(Int32.Parse(listBox1.SelectedItem.ToString().Split()[0]));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1?.SelectedItem != null) { 
                Zheck z = controller.getById(Int32.Parse(listBox1?.SelectedItem?.ToString().Split()[0]));
                textBox8.Text = z.Region1;
                textBox6.Text = z.Name1;
                numericUpDown3.Value = (decimal)z.NumberHabitians1;
                numericUpDown4.Value = (decimal)z.NumberOfBuildings1;   
            }
        }
    }
}
