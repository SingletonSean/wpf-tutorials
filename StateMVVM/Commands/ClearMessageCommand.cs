using MVVMEssentials.Commands;
using StateMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace StateMVVM.Commands
{
    public class ClearMessageCommand : CommandBase
    {
        private readonly MessageStore _messageStore;

        public ClearMessageCommand(MessageStore messageStore)
        {
            _messageStore = messageStore;
        }

        public override void Execute(object parameter)
        {
            _messageStore.ClearCurrentMessage();
        }
    }
}
