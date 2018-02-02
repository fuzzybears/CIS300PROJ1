/* UserInterface.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ksu.Cis300.CapitalGainCalculator
{
    /// <summary>
    /// A user interface for a simple captial gain calculator for a single stock commodity.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Declare Queue to store shares
        /// </summary>
        Queue<decimal> _q1 = new Queue<decimal>();
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }
        /// <summary>
        /// How many shares are we buying and at what cost
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxBuy_Click(object sender, EventArgs e)
        {
            decimal cost = uxCost.Value;
            decimal number = uxNumber.Value;

            for (int i = 0; i < number; i++)
            {
                _q1.Enqueue(cost);

            }
            uxOwned.Text = Convert.ToString(_q1.Count);
            
        }
        /// <summary>
        /// Sell button calculates captial gain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSell_Click(object sender, EventArgs e)
        {

            decimal originalCost;
            decimal newCost = uxCost.Value;
            decimal number = uxNumber.Value;
            
            decimal firstCalc = 0;
            decimal calc = Convert.ToDecimal(uxGain.Text);
            if (number > _q1.Count)
            {
                MessageBox.Show("You do not have that many shares");
            }
            else
            {

                for (int i = 0; i < number; i++)
                {
                    originalCost = _q1.Dequeue();
                    firstCalc = newCost - originalCost;
                    calc += firstCalc;
                }
                uxOwned.Text = Convert.ToString(_q1.Count);
                uxGain.Text = Convert.ToString(calc);
            }
        }
    }
}
