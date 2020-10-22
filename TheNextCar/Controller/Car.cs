using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNextCar.Controller
{
    class Car
    {

        AccubaterryController accubaterryController;
        DoorController doorController;
        OnCarEngineStatusChanged callbackCarEngineStatusChanged;

        public Car(AccubaterryController accubaterryController,
                   DoorController doorController,
                   OnCarEngineStatusChanged callbackCarEngineStatusChanged)
        {
            this.accubaterryController = accubaterryController;
            this.doorController = doorController;
            this.callbackCarEngineStatusChanged = callbackCarEngineStatusChanged;
        }

        public void turnOnPower()
        {
            this.accubaterryController.turnOn();
        }
        public void turnOfPower()
        {
            this.accubaterryController.turnOff();
        }

        public bool powerIsReady()
        {
            return this.accubaterryController.accubatterryIsOn();
        }

        public void closeTheDoor()
        {
            this.doorController.close();
        }
        public void openTheDoor()
        {
            this.doorController.open();
        }
        public void lockTheDoor()
        {
            this.doorController.activateLock();
        }
        public void unlockTheDoor()
        {
            this.doorController.unlock();
        }
        private bool doorIsClosed()
        {
            return this.doorController.isClose();
        }
        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }
        public void toggleStartEngineButton()
        {
            if (!doorIsClosed())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "Door is Open");
                return;
            }
            if (!doorIsLocked())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED", "Door Unlocked");
                return;
            }
            if (!powerIsReady())
            {
                this.callbackCarEngineStatusChanged.carEngineStatusChanged("STOPPED",
                         "Power is Off");
                return;
            }
            this.callbackCarEngineStatusChanged.carEngineStatusChanged("STARTED", "Engine Started");
        }
        public void toggleTheLoockDoorButton()
        {

            if (!doorIsLocked())
            {
                this.lockTheDoor();
            }
            else
            {
                this.unlockTheDoor();
            }
        }

        public void toggleTheDoorButton()
        {
            if (!doorIsClosed())
            {
                this.closeTheDoor();
            }
            else
            {
                this.openTheDoor();
            }
        }
        public void toggleThePowerButton()
        {
            if (!powerIsReady())
            {
                this.turnOnPower();
            }
            else
            {
                this.turnOfPower();
            }
        }
    }
    interface OnCarEngineStatusChanged
    {
        void carEngineStatusChanged(string value, string message);
    }
} 

