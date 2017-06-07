using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Low_Level_Objects_Library;

namespace Game_Class_Library {
    public static class Solitaire {
       
        // 
        private static CardPile drawPile;
        private static CardPile discardPile;

        //Piles for the individual suits
        private static CardPile suitPileOne;
        private static CardPile suitPileTwo;
        private static CardPile suitPileThree;
        private static CardPile suitPileFour;

        //Piles for all the tables
        private static CardPile tableau1;
        private static CardPile tableau2;
        private static CardPile tableau3;
        private static CardPile tableau4;
        private static CardPile tableau5;
        private static CardPile tableau6;
        private static CardPile tableau7;

        private const int CARDS_IN_SUIT = 13; //Amount of cards per suit
        private const int AMOUNT_OF_TABLES = 7; //Amout of tables

        private static int[] tableCardsInPlay = new int[8]; //the amount if playable cards per table. index at 1 to allow index to match table number

        //Game Setup
        public static void SetUpGame() {
            drawPile = new CardPile(true);
            discardPile = new CardPile();
            suitPileOne = new CardPile();
            suitPileTwo = new CardPile();
            suitPileThree = new CardPile();
            suitPileFour = new CardPile();

            drawPile.Shuffle();
            discardPile.Add(drawPile.DealOneCard());
            tableau1 = TableauInitialise(1);
            tableau2 = TableauInitialise(2);
            tableau3 = TableauInitialise(3);
            tableau4 = TableauInitialise(4);
            tableau5 = TableauInitialise(5);
            tableau6 = TableauInitialise(6);
            tableau7 = TableauInitialise(7);

            //sets up the cards in play array, with the index at 1
            tableCardsInPlay[0] = 0;
            for (int i = 1; i < tableCardsInPlay.Length; i++) {
                tableCardsInPlay[i] = 1;
            }

        }
        /// <summary>
        /// Initialise Tableau
        /// </summary>
        /// <param name="amountOfCards"></param>
        /// <returns></returns>
        //Sets a single table at the start of the game
        private static CardPile TableauInitialise(int amountOfCards)
        {
            CardPile tableau = new CardPile();
            for (int i = 0; i < amountOfCards; i++)
            {
                tableau.Add(drawPile.DealOneCard());
            }
            return tableau;
        }

        /// <summary>
        /// Draw 1 card from Draw Table
        /// </summary>
        public static void DrawCard() {
            discardPile.Add(drawPile.DealOneCard());
        } 

        /// <summary>
        /// Reset draw pile when there is no card to draw
        /// </summary>
        public static void ResetDrawPile() {
            drawPile = discardPile;
            discardPile = new CardPile();
            discardPile.Add(drawPile.DealOneCard());
        }

        /// <summary>
        /// Check if user have won the game base on the number of card in each suit pile
        /// </summary>
        /// <returns></returns>
        public static bool HasWon() {
            if ((suitPileOne.GetCount() == CARDS_IN_SUIT) && (suitPileTwo.GetCount() == CARDS_IN_SUIT) && (suitPileThree.GetCount() == CARDS_IN_SUIT) && (suitPileFour.GetCount() == CARDS_IN_SUIT)) {
                return true;
            } else {
                return false;
            }
        } // end HasWon

        /// <summary>
        /// Check a card if it is an Ace
        /// </summary>
        /// <param name="played">Card: parameter of a card in list</param>
        /// <returns></returns>
        public static bool IfAce(Card played)
        {
            if (played.GetFaceValue() == FaceValue.Ace)
            {
                return true;
            }
            else {
                return false;
            }
        } // end IfAce


        /// <summary>
        /// Make a move of 2 card after check the requested move is a vaild or not
        /// </summary>
        /// <param name="begin">Card: Grab the card need to move</param>
        /// <param name="end">Card: Grab the card's new position</param>
        /// <param name="location">string: paramenter of "table", "pile" or "suit"</param>
        /// <param name="destination">string: parameter of "table", "pile" or "suit" </param>
        /// <returns></returns>
        public static bool MoveCard(Card begin, Card end, string location, string destination) {
            if ((location == "table") && (destination == "table")) {
                if (MoveControl(begin, end) == true) {
                    //Grabs the card(s) to be played and removes them
                    Card[] stack = MoveBlock(begin);
                    int tableNum = FindTable(begin);
                    //removes card(s) in the stack from the table
                    CleanBlock(stack, tableNum);
                    AddToTable(stack, end);
                    return true;
                } else {
                    return false;
                }
            } else if ((location == "table") && (destination == "suit")) {
                if (MoveControlSuit(begin, end) == true) {
                    //Grabs the card(s) to be played and removes them
                    Card[] stack = MoveBlock(begin);
                    //Checks if the stack has only one card in it
                    if (stack.Length == 1) {
                        int tableNum = FindTable(begin);
                        CleanBlock(stack, tableNum);
                        SuitPlace(begin, end);
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            } else if ((location == "discard") && (destination == "table")) {
                if (MoveControl(begin, end) == true) {
                    MoveDiscardPile(begin);
                    //Card put into an array to work seemlessly with existing code 
                    Card[] stack = { begin };
                    AddToTable(stack, end);
                    return true;
                } else {
                    return false;
                }
            } else if ((location == "discard") && (destination == "suit")) {
                if (MoveControlSuit(begin, end) == true) {
                    MoveDiscardPile(begin);
                    SuitPlace(begin, end);
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        } // end MoveCard

        /// <summary>
        /// Check a move of 2 card valid or not
        /// </summary>
        /// <param name="played">Card: the card widthdraw from the Tableau Piles</param>
        /// <param name="destination">Card: the destination of the played card</param>
        /// <returns></returns>
        public static bool MoveControl(Card played, Card destination) {

            if ((destination.GetFaceValue() == FaceValue.Two) && (played.GetFaceValue() == FaceValue.Ace) && (destination.GetColour() != played.GetColour())) {
                return true;
                //Special check for Tens and Jacks due to comparative errors 
            } else if ((destination.GetFaceValue() == FaceValue.Jack) && (played.GetFaceValue() == FaceValue.Ten) && (destination.GetColour() != played.GetColour())) {
                return true;
            } else if ((destination.GetFaceValue() == played.GetFaceValue() + 1) && (destination.GetColour() != played.GetColour())) {
                return true;
            } else {
                return false;
            }
        } // end MoveControl
        

        /// <summary>
        /// Similar to MoveControl but for the suit piles, as suits need to match up
        /// </summary>
        /// <param name="played">Card: Check a card in Tableau or Discard Pild </param>
        /// <param name="destination">Card: Destination of the card in Suit Pile</param>
        /// <returns></returns>
        public static bool MoveControlSuit(Card played, Card destination) {
            if ((destination.GetFaceValue() == FaceValue.Ace) && (played.GetFaceValue() == FaceValue.Two) && (played.GetSuit() == destination.GetSuit())) {
                return true;
            } else if ((destination.GetFaceValue() == FaceValue.Ten) && (played.GetFaceValue() == FaceValue.Jack) && (played.GetSuit() == destination.GetSuit())) {
                return true;
            } else if ((destination.GetFaceValue() + 1 == played.GetFaceValue()) && (played.GetSuit() == destination.GetSuit())) {
                return true;
            } else {
                return false;
            }
        } // end MoveControlSuit

        
        /// <summary>
        /// Check if the a Face-down-card can be flip over or not
        /// </summary>
        /// <param name="tableNum"></param>
        /// <returns></returns>
        public static bool CheckTurnOver(int tableNum) {
            if (GetTableCount(tableNum) != 0) {
                //Checks if there is any face up cards already in the table
                if (tableCardsInPlay[tableNum] == 0) {
                    tableCardsInPlay[tableNum]++;
                }
                return true;
            } else {
                return false;
            }
        } // end CheckTurnOver

        /// <summary>
        /// Finds correct table and adds all the cards in the stack to the table
        /// </summary>
        /// <param name="played"></param>
        /// <param name="destination"></param>
        private static void AddToTable(Card[] played, Card destination)
        {
            //
            if ((tableau1.GetCount() != 0) && (tableau1.GetLastCardInPile() == destination))
            {
                for (int i = 0; i < played.Length; i++)
                {
                    tableau1.Add(played[i]);
                    tableCardsInPlay[1]++;
                }
            }
            else if ((tableau2.GetCount() != 0) && (tableau2.GetLastCardInPile() == destination))
            {
                for (int i = 0; i < played.Length; i++)
                {
                    tableau2.Add(played[i]);
                    tableCardsInPlay[2]++;
                }
            }
            else if ((tableau3.GetCount() != 0) && (tableau3.GetLastCardInPile() == destination))
            {
                for (int i = 0; i < played.Length; i++)
                {
                    tableau3.Add(played[i]);
                    tableCardsInPlay[3]++;
                }
            }
            else if ((tableau4.GetCount() != 0) && (tableau4.GetLastCardInPile() == destination))
            {
                for (int i = 0; i < played.Length; i++)
                {
                    tableau4.Add(played[i]);
                    tableCardsInPlay[4]++;
                }
            }
            else if ((tableau5.GetCount() != 0) && (tableau5.GetLastCardInPile() == destination))
            {
                for (int i = 0; i < played.Length; i++)
                {
                    tableau5.Add(played[i]);
                    tableCardsInPlay[5]++;
                }
            }
            else if ((tableau6.GetCount() != 0) && (tableau6.GetLastCardInPile() == destination))
            {
                for (int i = 0; i < played.Length; i++)
                {
                    tableau6.Add(played[i]);
                    tableCardsInPlay[6]++;
                }
            }
            else if ((tableau7.GetCount() != 0) && (tableau7.GetLastCardInPile() == destination))
            {
                for (int i = 0; i < played.Length; i++)
                {
                    tableau7.Add(played[i]);
                    tableCardsInPlay[7]++;
                }
            }

        }

        /// <summary>
        /// Grab a number of card that already arranged in the corect order
        /// </summary>
        /// <param name="played"></param>
        /// <returns></returns>
        private static Card[] MoveBlock(Card played) {
            Card[] stack = new Card[1]; //Stack of cards to be moved
            CardPile tempTable = new CardPile(); //temporary cardpile to hold the table cardpile
            //find the table the played card comes from
            int tableNum = FindTable(played);
            tempTable = GetTable(tableNum);
            //Grab the played cards from the table
            stack = GetCards(played, tempTable, tableNum);
            return stack;
        } // end MoveBlock


        /// <summary>
        /// Get the card form a tableau
        /// </summary>
        /// <param name="played">the location of the card need to get</param>
        /// <param name="table"> the table where the card located</param>
        /// <param name="tableNum">Table number of the card</param>
        /// <returns></returns>
        private static Card[] GetCards(Card played, CardPile table, int tableNum) {
            //initialize stack to hold the grabed cards and counter varible max
            Card[] stack = new Card[1];
            int max = 0;
            for (int i = 0; i < GetTableCount(tableNum); i++) {
                if (table.GetCard((GetTableCount(tableNum) - 1) - i) == played) {
                    max = i;
                    stack = new Card[max + 1];
                    break;
                }
            }
            //Grab them from the last card up to the clicked card for redisplaying purposes
            for (int j = max; j > -1; j--) {
                stack[max - j] = table.GetCard((table.GetCount() - 1) - j);
            }
            return stack;
        }

        /// <summary>
        /// Not implement yet!
        /// Remove a full block of card in the correct order from the table
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="table"></param>
        private static void CleanBlock(Card[] stack, int table) {
            //tempoary table variable, inplay variable and while loop control initiziation
            CardPile tempTable = GetTable(table);
            int tempInPlay = GetTableCardsInPlay(table);
            bool allRemoved = false;
            while (!allRemoved) {
                //loop each card in the stack and remove it from the table
                for (int i = 0; i < stack.Length; i++) {
                    for (int j = 0; j < GetTableCount(table); j++) {
                        if (tempTable.GetCard(j) == stack[i]) {
                            tempTable.RemoveCard(j);
                            tempInPlay--;
                            break;
                        }
                    }

                }
                //check if all the cards have been removed from the table
                int count = 0;
                for (int i = 0; i < tempTable.GetCount(); i++) {
                    for (int j = 0; j < stack.Length; j++) {
                        if (tempTable.GetCard(i) == stack[j]) {
                            count++;
                        }
                    }
                }
                if (count > 0) {
                    //reset the temporary table and repeat process
                    tempTable = GetTable(table);
                    tempInPlay = GetTableCardsInPlay(table);
                } else {
                    //else kill loop
                    allRemoved = true;
                }
            }
            SetNewTable(tempTable, table, tempInPlay);

        } //end CleanBlock


        //
        /// <summary>
        /// Reassign the updated table 
        /// </summary>
        /// <param name="tmp">CardPile: temporary table</param>
        /// <param name="tableNum">int: Old table number</param>
        /// <param name="inPlay">int: table number need to assign</param>
        private static void SetNewTable(CardPile tmp, int tableNum, int inPlay) {
            tableCardsInPlay[tableNum] = inPlay;
            switch (tableNum) {
                case 1:
                    tableau1 = tmp;
                    break;
                case 2:
                    tableau2 = tmp;
                    break;
                case 3:
                    tableau3 = tmp;
                    break;
                case 4:
                    tableau4 = tmp;
                    break;
                case 5:
                    tableau5 = tmp;
                    break;
                case 6:
                    tableau6 = tmp;
                    break;
                case 7:
                    tableau7 = tmp;
                    break;
            }
        }
        /// <summary>
        /// Move a card out of the Discard Pile
        /// </summary>
        /// <param name="played">Card: the card on the top of the Discard Pile</param>
        private static void MoveDiscardPile(Card played) {
            CardPile saved = discardPile;
            bool removed = false;
            while (!removed) {
                discardPile.RemoveLastCard();
                if (discardPile.ContainsCard(played)) {
                    discardPile = saved;
                } else {
                    removed = true;
                }
            }
        }
        /// <summary>
        /// Fing the Table Number where the card came from
        /// </summary>
        /// <param name="played">Card: the clicked card</param>
        /// <returns></returns>
        private static int FindTable(Card played) {
            for (int table = 1; table <= AMOUNT_OF_TABLES; table++) {
                if ((GetTableCount(table) != 0) && (GetTable(table).ContainsCard(played) == true)) {
                    return table;
                }
            }
            return 0;
        }
        
        /// <summary>
        /// Place a card in a Suit Pile
        /// </summary>
        /// <param name="played"></param>
        /// <param name="destination"></param>
        private static void SuitPlace(Card played, Card destination) {
            if ((suitPileOne.GetCount() != 0) && (suitPileOne.GetLastCardInPile().GetSuit() == destination.GetSuit())) {
                suitPileOne.Add(played);
            } else if ((suitPileTwo.GetCount() != 0) && (suitPileTwo.GetLastCardInPile().GetSuit() == destination.GetSuit())) {
                suitPileTwo.Add(played);
            } else if ((suitPileThree.GetCount() != 0) && (suitPileThree.GetLastCardInPile().GetSuit() == destination.GetSuit())) {
                suitPileThree.Add(played);
            } else if ((suitPileFour.GetCount() != 0) && (suitPileFour.GetLastCardInPile().GetSuit() == destination.GetSuit())) {
                suitPileFour.Add(played);
            }

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ace"></param>
        /// <param name="location"></param>
        public static void PlayAce(Card ace, string location) {
            //Determines whether the card is in the discard pile or a table
            if (location == "discard") {
                MoveDiscardPile(ace);
            } else {
                if ((tableau1.GetCount() != 0) && (tableau1.GetLastCardInPile() == ace)) {
                    tableau1.RemoveLastCard();
                    tableCardsInPlay[1]--;
                } else if ((tableau2.GetCount() != 0) && (tableau2.GetLastCardInPile() == ace)) {
                    tableau2.RemoveLastCard();
                    tableCardsInPlay[2]--;
                } else if ((tableau3.GetCount() != 0) && (tableau3.GetLastCardInPile() == ace)) {
                    tableau3.RemoveLastCard();
                    tableCardsInPlay[3]--;
                } else if ((tableau4.GetCount() != 0) && (tableau4.GetLastCardInPile() == ace)) {
                    tableau4.RemoveLastCard();
                    tableCardsInPlay[4]--;
                } else if ((tableau5.GetCount() != 0) && (tableau5.GetLastCardInPile() == ace)) {
                    tableau5.RemoveLastCard();
                    tableCardsInPlay[5]--;
                } else if ((tableau6.GetCount() != 0) && (tableau6.GetLastCardInPile() == ace)) {
                    tableau6.RemoveLastCard();
                    tableCardsInPlay[6]--;
                } else if ((tableau7.GetCount() != 0) && (tableau7.GetLastCardInPile() == ace)) {
                    tableau7.RemoveLastCard();
                    tableCardsInPlay[7]--;
                }
            }

            if (suitPileOne.GetCount() == 0) {
                suitPileOne.Add(ace);
            } else if (suitPileTwo.GetCount() == 0) {
                suitPileTwo.Add(ace);
            } else if (suitPileThree.GetCount() == 0) {
                suitPileThree.Add(ace);
            } else {
                suitPileFour.Add(ace);
            }
        }
        public static Card GetSuitPile(int suitNum)
        {
            switch (suitNum)
            {
                case 1:
                    return suitPileOne.GetLastCardInPile();
                case 2:
                    return suitPileTwo.GetLastCardInPile();
                case 3:
                    return suitPileThree.GetLastCardInPile();
                case 4:
                    return suitPileFour.GetLastCardInPile();
                default:
                    return new Card();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableNum"></param>
        /// <returns></returns>

        public static int GetTableCount(int tableNum)
        {
            switch (tableNum)
            {
                case 1:
                    return tableau1.GetCount();
                case 2:
                    return tableau2.GetCount();
                case 3:
                    return tableau3.GetCount();
                case 4:
                    return tableau4.GetCount();
                case 5:
                    return tableau5.GetCount();
                case 6:
                    return tableau6.GetCount();
                case 7:
                    return tableau7.GetCount();
                default:
                    return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableNum"></param>
        /// <returns></returns>
        public static int GetTableCardsInPlay(int tableNum)
        {
            return tableCardsInPlay[tableNum];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableNum"></param>
        /// <returns></returns>
        public static CardPile GetTable(int tableNum)
        {
            switch (tableNum)
            {
                case 1:
                    return tableau1;
                case 2:
                    return tableau2;
                case 3:
                    return tableau3;
                case 4:
                    return tableau4;
                case 5:
                    return tableau5;
                case 6:
                    return tableau6;
                case 7:
                    return tableau7;
                default:
                    return new CardPile();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="king"></param>
        /// <param name="location"></param>
        /// <param name="tableNum"></param>
        public static void PlayKing(Card king, string location, int tableNum) {
            Card[] stack = new Card[1];
            //determines where the king starts and move it accordingly
            if (location == "discard") {
                MoveDiscardPile(king);
                stack[0] = king;
            } else {
                stack = MoveBlock(king);
                int startTable = FindTable(king);
                CleanBlock(stack, startTable);
            }
            switch (tableNum) {
                case 1:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau1.Add(stack[i]);
                        tableCardsInPlay[1]++;
                    }
                    break;
                case 2:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau2.Add(stack[i]);
                        tableCardsInPlay[2]++;
                    }
                    break;
                case 3:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau3.Add(stack[i]);
                        tableCardsInPlay[3]++;
                    }
                    break;
                case 4:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau4.Add(stack[i]);
                        tableCardsInPlay[4]++;
                    }
                    break;
                case 5:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau5.Add(stack[i]);
                        tableCardsInPlay[5]++;
                    }
                    break;
                case 6:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau6.Add(stack[i]);
                        tableCardsInPlay[6]++;
                    }
                    break;
                case 7:
                    for (int i = 0; i < stack.Length; i++) {
                        tableau7.Add(stack[i]);
                        tableCardsInPlay[7]++;
                    }
                    break;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetSuitThreeCount()
        {
            return suitPileThree.GetCount();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetSuitTwoCount()
        {
            return suitPileTwo.GetCount();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetSuitFourCount()
        {
            return suitPileFour.GetCount();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Card GetTopDiscard() {
            return discardPile.GetLastCardInPile();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetDrawPileCount()
        {
            return drawPile.GetCount();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetDiscardCount() {
            return discardPile.GetCount();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetSuitOneCount() {
            return suitPileOne.GetCount();
        }
        
        
       
    }
}
