/*
    This file is part of ZWaveLib Project source code.

    ZWaveLib is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    ZWaveLib is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with ZWaveLib.  If not, see <http://www.gnu.org/licenses/>.  
*/

/*
 *     Author: Generoso Martello <gene@homegenie.it>
 *     Project Homepage: https://github.com/genielabs/zwave-lib-dotnet
 */

using System;
using ZWaveLib.Values;

namespace ZWaveLib.CommandClasses
{
    public class SensorBinary : ICommandClass
    {
        public CommandClass GetClassId()
        {
            return CommandClass.SensorBinary;
        }

        public NodeEvent GetEvent(ZWaveNode node, byte[] message)
        {
            NodeEvent nodeEvent = null;
            byte cmdType = message[1];
            if (cmdType == (byte)Command.SensorBinaryReport)
            {
                nodeEvent = new NodeEvent(node, EventParameter.SensorGeneric, message[2], 0);
            }
            return nodeEvent;
        }

        public static void Get(ZWaveNode node)
        {
            node.SendDataRequest(new byte[] { 
                (byte)CommandClass.SensorBinary, 
                (byte)Command.SensorBinaryGet 
            });
        }
    }
}


