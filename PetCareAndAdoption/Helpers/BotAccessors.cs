﻿using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using OpenAI_API.Chat;
using PetCareAndAdoption.Bots.Accessories;

namespace PetCareAndAdoption.Helpers
{
    public class BotAccessors
    {
        public BotAccessors(ConversationState conversationState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
        }

        public static string PetBotStateAccessorName { get; } = $"{nameof(BotAccessors)}.FindPetState";
        public IStatePropertyAccessor<FindPetState> PetBotStateAccessor { get; internal set; }

        public static string DialogStateAccessorName { get; } = $"{nameof(BotAccessors)}.DialogState";
        public IStatePropertyAccessor<DialogState> DialogStateAccessor { get; internal set; }
        public ConversationState ConversationState { get; }
    }
}
