using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace Event
{
    public class EventActions : MonoBehaviour
    {
        //public event
        public void LeaveEvent()
        {
            print("leave");
            return;
        }
        #region TresureBox
        //OpenTreasureChest
        public void AcuireRandomItem()
        {
            print("new box");
        }
        public void AcuireRandomRareItem()
        {
            print("normal box");
        }
        public void AcuireRadomArtifactItem()
        {
            print("old box");
        }
        #endregion

        #region HelpFallenGuy
        public void AcuireRandomBoyCard()
        {
            print("cain water");
        }
        public void AcuireRandomGirlCard()
        {
            print("abel water");
        }
        #endregion

        #region Sacrifice
        public void AcuireBoyCardFromThree()
        {
            print("cain protect abel");
        }
        public void AcuireGirlCardFromThree()
        {
            print("abel hit birdstrike");
        }
        #endregion

        #region Greed
        public void AcuireRandomItemInGreed()
        {
            print("cain Steal item");
        }
        #endregion

        #region Swear
        public void DecreaseRelationshipFromGirl()
        {
            print("abel angry");
        }
        public void AcuireItmeFromGirlAngry()
        {
            print("cain : calm down abel");
        }
        #endregion

        #region FortuneTeller
        public void AcuireItemForRelationship()
        {
            print("future good or nor or bad");
        }
        #endregion

        #region Donation
        public void IncreaseRelationshipFromItem()
        {
            print("donation");
        }
        public void AcuireRandomCard()
        {
            print("not donation");
        }
        #endregion

        #region Pray
        public void RemoveOneCard()
        {
            print("pray");
        }
        public void RemoveItemAndTwoCard()
        {
            print("donate money");
        }
        #endregion

        #region Night Duty
        public void DeleteGirlToAcuireBoyCard()
        {
            print("cain stand");
        }
        public void DeleteBoyToAcuireGirlCard()
        {
            print("abel stand");
        }
        #endregion

        #region Storm
        public void IncreaseRelationship()
        {
            print("storm is good");
        }
        #endregion

        #region Backstab
        public void DecreaseRelationship()
        {
            print("people told you shit");
        }
        #endregion

        #region Desire
        public void CurseFromItem()
        {
            print("curse in our");
        }
        #endregion

        #region Be stolen
        public void RemoveAllItem()
        {
            print("steal my item");
        }
        #endregion

        #region Insult each other
        //EngageInConflict
        public void BadRelationshipInThreeTime()
        {
            print("fight together");
        }
        #endregion

        #region Take test 
        //TakeTheTest
        public void UpgradeAllBoyCard()
        {
            print("test cain");
        }
        public void UpgradeAllGirlCard()
        {
            print("test abel");
        }
        #endregion

        #region Speak candidly
        public void GoodRelationshipInThreeTime()
        {
            print("talk together");
        }
        #endregion

        #region Make a sacrifice
        public void RemoveItemAndUpgradeSelectedCard()
        {
            print("donate Item");
        }
        #endregion

        #region Give up food
        public void UpgradeBoyCard()
        {
            print("cain give food");
        }
        public void UpgradeGirlCard()
        {
            print("abel give food");
        }
        #endregion

        #region Predictor
        public void UpgradeChoseCard()
        {
            print("Winter is comming");
        }
        #endregion
    }
}

