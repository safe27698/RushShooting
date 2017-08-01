using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;
using SgLib.UI;
using EasyMobile;
//using EasyMobile.Demo;

#if EM_UIAP
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Security;
#endif

public class IAP : MonoBehaviour
{
	void OnEnable()
	{            
		IAPManager.PurchaseCompleted += IAPManager_PurchaseCompleted;
		IAPManager.PurchaseFailed += IAPManager_PurchaseFailed;
		IAPManager.RestoreCompleted += IAPManager_RestoreCompleted;
	}

	void OnDisable()
	{
		IAPManager.PurchaseCompleted -= IAPManager_PurchaseCompleted;
		IAPManager.PurchaseFailed -= IAPManager_PurchaseFailed;   
		IAPManager.RestoreCompleted -= IAPManager_RestoreCompleted;
	}

	void IAPManager_PurchaseCompleted(IAPProduct product)
	{
		print (product.Name);

		if(product.Name == "Diamond100")
		{
			UI_Manager.AddDiamond.Invoke (100);
		}
		else if(product.Name == "Diamond500")
		{
			UI_Manager.AddDiamond.Invoke (500);
		}
		else if(product.Name == "Diamond1000")
		{
			UI_Manager.AddDiamond.Invoke (1000);
		}

		MobileNativeUI.Alert("Purchased Completed", "The purchase of product " + product.Name + " has completed successfully. This is when you should grant the buyer digital goods.");
	}

	void IAPManager_PurchaseFailed(IAPProduct product)
	{
		MobileNativeUI.Alert("Purchased Failed", "The purchase of product " + product.Name + " has failed.");
	}

	void IAPManager_RestoreCompleted()
	{
		MobileNativeUI.Alert("Restore Completed", "Your purchases have been restored successfully.");
	}

	void Start()
	{

	}

	void Update()
	{

	}


	public void Purchase_Diamond100()
	{

		IAPManager.Purchase(EM_IAPConstants.Product_Diamond100);

	}
	public void Purchase_Diamond500()
	{

		IAPManager.Purchase(EM_IAPConstants.Product_Diamond500);

	}
	public void Purchase_Diamond1000()
	{

		IAPManager.Purchase(EM_IAPConstants.Product_Diamond1000);

	}	



}



