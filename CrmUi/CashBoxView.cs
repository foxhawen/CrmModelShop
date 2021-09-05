using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrmBl.Model;

namespace CrmUi
{
    class CashBoxView
    {
        CashDesk cashDesk;

        public Label CeshDeskName { get; set; }
        public NumericUpDown Price { get; set; }
        public ProgressBar QueueLenght { get; set; }
        public Label LeaveCustomersCount { get; set; }

        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            this.cashDesk = cashDesk;

            CeshDeskName = new Label();
            Price = new NumericUpDown();
            QueueLenght = new ProgressBar();
            LeaveCustomersCount = new Label();

            CeshDeskName.AutoSize = true;
            CeshDeskName.Location = new System.Drawing.Point(x, y);
            CeshDeskName.Name = "label" + number;
            CeshDeskName.Size = new System.Drawing.Size(35, 13);
            CeshDeskName.TabIndex = number;
            CeshDeskName.Text = cashDesk.ToString();

            Price.Location = new System.Drawing.Point(x + 70, y);
            Price.Name = "numericUpDown" + number;
            Price.Size = new System.Drawing.Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = 10000000000000;

            QueueLenght.Location = new System.Drawing.Point(x + 250, y);
            QueueLenght.Maximum = cashDesk.MaxQueueLenght;
            QueueLenght.Name = "progressBar" + number;
            QueueLenght.Size = new System.Drawing.Size(100, 23);
            QueueLenght.TabIndex = number;
            QueueLenght.Value = 0;

            LeaveCustomersCount.AutoSize = true;
            LeaveCustomersCount.Location = new System.Drawing.Point(x + 400, y);
            LeaveCustomersCount.Name = "label2" + number;
            LeaveCustomersCount.Size = new System.Drawing.Size(35, 13);
            CeshDeskName.TabIndex = number;
            LeaveCustomersCount.Text = "";

            cashDesk.CheckClosed += CashDeskOnCheckClosed;
        }

        private void CashDeskOnCheckClosed(object sender, Check e)
        {

            Price.Invoke((Action)delegate
            {
                Price.Value += e.Price;
                QueueLenght.Value = cashDesk.Count;
                LeaveCustomersCount.Text = cashDesk.ExitCustomer.ToString();
            });

        }
    }
}
