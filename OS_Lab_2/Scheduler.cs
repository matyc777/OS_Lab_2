using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OS_Lab_2
{
    class Scheduler
    {
        static int turn = 0;
        static int[] interested = new int[Constants.N];

        static public void Lock(int ProcessID)
        {
            if (Peterson.peterson != null) Peterson.peterson.ChangeTxtBox(ProcessID.ToString() + " TRIES TO ENTER to enter into the critical region.\n");
            interested[ProcessID] = Constants.TRUE;
            turn = ProcessID;
            int other = 1 - ProcessID;

            while (turn == ProcessID && interested[other] == Constants.TRUE)
            {
                /*if (Peterson.peterson != null)*/ Peterson.peterson.ChangeTxtBox(ProcessID.ToString() + " WAITING.\n");
                Thread.Sleep(500);
            }
        }

        static public void Unlock(int ProcessID)
        {
            interested[ProcessID] = Constants.FALSE;
        }
    }
}
