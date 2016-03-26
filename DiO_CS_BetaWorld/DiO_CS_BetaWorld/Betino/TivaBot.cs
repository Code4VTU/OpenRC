using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Betino
{
    public class TivaBot : Communicator
    {

        #region Constants

        private const string TERMIN = "\n";
        
        #endregion

        #region Variables

        /// <summary>
        /// Delimiting characters.
        /// </summary>
        private char[] delimiterChars = { '\n' };

        private int[] steps = new int[6];

        #endregion

        #region Constructor / Destructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="port">Comunication port.</param>
        public TivaBot(string portName) : base(portName)
        {

        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~TivaBot()
        {
            this.Dispose(false);
        }

        #endregion

        #region Public Methods

        public void Steer(int leftSpeed, int rightSpeed)
        {
            string leftDirection = "F";
            string rightDirection = "F";

            if (leftSpeed > 0)
            {
                leftDirection = "F";
            }
            else if (leftSpeed < 0)
            {
                leftDirection = "B";
            }

            if (rightSpeed > 0)
            {
                rightDirection = "F";
            }
            else if (rightSpeed < 0)
            {
                rightDirection = "B";
            }


            string command = String.Format("?L{0}{1:D3}R{2}{3:D3}\n", leftDirection, Math.Abs(leftSpeed), rightDirection, Math.Abs(rightSpeed));
            Console.WriteLine(command);
            this.SendRequest(command);
        }

        #endregion
    }
}
