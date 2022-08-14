using System;
using System.Collections;
using System.Collections.Generic;
using App.OutPuts;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Components
{
    public class DialogView : MonoBehaviour, IDialogOutPut
    {
        [SerializeField] Button close;
        [SerializeField] Button positive;
        [SerializeField] Button negative;
        [SerializeField] TextMeshProUGUI description;
        
        public void Close()
        {
            positive.onClick.RemoveAllListeners();
            negative.onClick.RemoveAllListeners();

            positive.gameObject.SetActive(false);
            negative.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

        public IObservable<Unit> GetNegativeObservable()
        {
            negative.gameObject.SetActive(true);
            return negative.OnClickAsObservable();
        }

        public IObservable<Unit> GetPositiveObservable()
        {
            positive.gameObject.SetActive(true);
            return positive.OnClickAsObservable();
        }

        public void SetDescription(string description)
        {
            this.description.text = description;
        }
    }
}