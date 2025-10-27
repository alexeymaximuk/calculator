using System;
using Newtonsoft.Json;
using Scrips.Features.Calculation.Domain.Models;
using UnityEngine;

namespace Scrips.Features.Saving.Domain.Models
{
    public class PlayerPrefsSavingService
    {
        private const string UserDataKey = "UserData";
        public void SaveData(CalculatorData data)
        {
            var json = JsonConvert.SerializeObject(data);
            PlayerPrefs.SetString(UserDataKey, json);
            PlayerPrefs.Save();
        }
        public CalculatorData LoadData()
        {
            var calculatorDataJson = PlayerPrefs.GetString(UserDataKey, string.Empty);
            if (string.IsNullOrEmpty(calculatorDataJson))
                return null;
            return JsonConvert.DeserializeObject<CalculatorData>(calculatorDataJson);
        }
    }
}
