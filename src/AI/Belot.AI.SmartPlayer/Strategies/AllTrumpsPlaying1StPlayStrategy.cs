﻿namespace Belot.AI.SmartPlayer.Strategies
{
    using System.Linq;
    using System.Threading;

    using Belot.Engine.Cards;
    using Belot.Engine.Players;

    public class AllTrumpsPlaying1StPlayStrategy : IPlayStrategy
    {
        public PlayCardAction PlayCard(PlayerPlayCardContext context, CardCollection playedCards)
        {
            foreach (var card in context.AvailableCardsToPlay)
            {
                if (card.Type == CardType.Jack && context.MyCards.Count(x => x.Suit == card.Suit) > 2)
                {
                    return new PlayCardAction(card);
                }

                if (card.Type == CardType.Nine
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Jack)))
                {
                    return new PlayCardAction(card);
                }

                if (card.Type == CardType.Ace
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Nine))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Jack)))
                {
                    return new PlayCardAction(card);
                }

                if (card.Type == CardType.Ten
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Ace))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Nine))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Jack)))
                {
                    return new PlayCardAction(card);
                }

                if (card.Type == CardType.King
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Ten))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Ace))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Nine))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Jack)))
                {
                    return new PlayCardAction(card);
                }

                if (card.Type == CardType.Queen
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.King))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Ten))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Ace))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Nine))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Jack)))
                {
                    return new PlayCardAction(card);
                }

                if (card.Type == CardType.Eight
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Queen))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.King))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Ten))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Ace))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Nine))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Jack)))
                {
                    return new PlayCardAction(card);
                }

                if (card.Type == CardType.Seven
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Eight))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Queen))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.King))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Ten))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Ace))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Nine))
                    && playedCards.Contains(Card.GetCard(card.Suit, CardType.Jack)))
                {
                    return new PlayCardAction(card);
                }
            }

            var teammate = context.MyPosition.GetTeammate();

            foreach (var cardSuit in Card.AllSuits)
            {
                if (context.Bids.Any(x => x.Player == teammate && x.Type == cardSuit.ToBidType())
                    && context.AvailableCardsToPlay.HasAnyOfSuit(cardSuit))
                {
                    return new PlayCardAction(
                        context.AvailableCardsToPlay.Where(x => x.Suit == cardSuit)
                            .OrderBy(x => x.TrumpOrder).FirstOrDefault());
                }
            }

            return new PlayCardAction(context.AvailableCardsToPlay.OrderBy(x => x.TrumpOrder).FirstOrDefault());
        }
    }
}
