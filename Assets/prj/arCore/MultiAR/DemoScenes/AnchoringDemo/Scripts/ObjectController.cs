using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{

    private Touch touch;
    //public Animator anim;
    [Tooltip("Toggle for Model1.")]
    public Toggle[] toggles;
    [Tooltip("Transform of Model1, if any.")]
    public Transform[] models;

    public MoverRotar paraUI;

    [Tooltip("Whether the virtual model should rotate at the AR-camera or not.")]
    public bool modelLookingAtCamera = false;

    [Tooltip("Whether the virtual model should be vertical, or orthogonal to the surface.")]
    public bool verticalModel = false;

    [Tooltip("UI-Text to show information messages.")]
    public Text infoText;

    // reference to the MultiARManager
    private MultiARManager arManager;

    // currently selected model
    public Transform currentModel = null;


    void Start()
    {
        // get reference to MultiARManager
        arManager = MultiARManager.Instance;

        if (infoText)
        {
            infoText.text = "Please select a model.";
        }

        paraUI = GameObject.Find("MoverRotar").GetComponent<MoverRotar>();

    }

    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        // don't consider taps over the UI

        //if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        //{
        //    return;
        //}

        // check for tap
        if (arManager && arManager.IsInitialized() && arManager.IsInputAvailable(true))
        {
            MultiARInterop.InputAction action = arManager.GetInputAction();

            if (action == MultiARInterop.InputAction.Click || action == MultiARInterop.InputAction.Grip)
            {
                
                // check if there is a model selected
                if (currentModel == null)
                {
                    Debug.LogError("No model selected!");
                    //paraUI.LimpiarBools();
                    return;

                }

                // update the currently selected model
                currentModel = GetModelHit();

                // raycast world
                MultiARInterop.TrackableHit hit;
                if (currentModel && arManager.RaycastToWorld(true, out hit))
                {
                    
                    // anchor the model if needed
                    if (currentModel.parent == null)
                    {
                        arManager.AnchorGameObjectToWorld(currentModel.gameObject, hit);
                    }

                    if(paraUI.mover == true)
                    {
                        SetModelWorldPos(hit.point, !verticalModel ? currentModel.rotation : Quaternion.identity);
                    }
                    // set the new position of the model
                }
            }
        }

        // update the info
        if (infoText)
        {
            infoText.text = currentModel ? "Selected: " + currentModel.gameObject.name : "No model selected";
        }

        //#region updatetogglestatus
        //// turn off the toggles, if the respective models are not active
        UpdateToggleStatus(toggles[0], models[0]);
        UpdateToggleStatus(toggles[1], models[1]);
        UpdateToggleStatus(toggles[2], models[2]);
        UpdateToggleStatus(toggles[3], models[3]);
        UpdateToggleStatus(toggles[4], models[4]);
        UpdateToggleStatus(toggles[5], models[5]);
        UpdateToggleStatus(toggles[6], models[6]);
        UpdateToggleStatus(toggles[7], models[7]);
        UpdateToggleStatus(toggles[8], models[8]);
        UpdateToggleStatus(toggles[9], models[9]);
        UpdateToggleStatus(toggles[10], models[10]);
        UpdateToggleStatus(toggles[11], models[11]);

        UpdateToggleStatus(toggles[12], models[12]);
        UpdateToggleStatus(toggles[13], models[13]);
        UpdateToggleStatus(toggles[14], models[14]);
        UpdateToggleStatus(toggles[15], models[15]);
        UpdateToggleStatus(toggles[16], models[16]);
        UpdateToggleStatus(toggles[17], models[17]);
        UpdateToggleStatus(toggles[18], models[18]);
        UpdateToggleStatus(toggles[19], models[19]);
        UpdateToggleStatus(toggles[20], models[20]);
        UpdateToggleStatus(toggles[21], models[21]);
        UpdateToggleStatus(toggles[22], models[22]);
        UpdateToggleStatus(toggles[23], models[23]);
        UpdateToggleStatus(toggles[24], models[24]);
        UpdateToggleStatus(toggles[25], models[25]);
        UpdateToggleStatus(toggles[26], models[26]);
        UpdateToggleStatus(toggles[27], models[27]);
        UpdateToggleStatus(toggles[28], models[28]);
        UpdateToggleStatus(toggles[29], models[29]);
        UpdateToggleStatus(toggles[30], models[30]);
        UpdateToggleStatus(toggles[31], models[31]);
        UpdateToggleStatus(toggles[32], models[32]);
        UpdateToggleStatus(toggles[33], models[33]);
        UpdateToggleStatus(toggles[34], models[34]);
        UpdateToggleStatus(toggles[35], models[35]);
        UpdateToggleStatus(toggles[36], models[36]);

        //#endregion

    }


    // returns the model hit by the input ray, or current model if no other was hit
    private Transform GetModelHit()
	{
		MultiARInterop.TrackableHit[] hits;
		if(arManager.RaycastAllToScene(true, out hits))
		{
			MultiARInterop.TrackableHit hit = hits[0];
			RaycastHit rayHit = (RaycastHit)hit.psObject;

			// check for hitting the same model
			if (currentModel != null) 
			{
				for (int i = hits.Length - 1; i >= 0; i--) 
				{
					hit = hits[i];
					rayHit = (RaycastHit)hit.psObject;

					if (rayHit.transform == currentModel) 
					{
						return currentModel;
					}
				}
			}

            #region GG

            // check for any of the models
            if(rayHit.transform == models[0])
			{
				return models[0];
			}
			else if(rayHit.transform == models[1])
			{
				return models[1];
			}
			else if(rayHit.transform == models[2])
			{
				return models[2];
			}
            else if (rayHit.transform == models[3])
            {
                return models[3];
            }
            else if (rayHit.transform == models[4])
            {
                return models[5];
            }
            else if (rayHit.transform == models[6])
            {
                return models[6];
            }
            else if (rayHit.transform == models[7])
            {
                return models[7];
            }
            else if (rayHit.transform == models[8])
            {
                return models[8];
            }
            else if (rayHit.transform == models[9])
            {
                return models[10];
            }
            else if (rayHit.transform == models[11])
            {
                return models[11];
            }

            else if (rayHit.transform == models[12])
            {
                return models[12];
            }
            else if (rayHit.transform == models[13])
            {
                return models[13];
            }
            else if (rayHit.transform == models[14])
            {
                return models[14];
            }
            else if (rayHit.transform == models[15])
            {
                return models[15];
            }
            else if (rayHit.transform == models[16])
            {
                return models[16];
            }
            else if (rayHit.transform == models[17])
            {
                return models[17];
            }
            else if (rayHit.transform == models[18])
            {
                return models[18];
            }
            else if (rayHit.transform == models[19])
            {
                return models[19];
            }
            else if (rayHit.transform == models[20])
            {
                return models[20];
            }
            else if (rayHit.transform == models[21])
            {
                return models[21];
            }
            else if (rayHit.transform == models[22])
            {
                return models[22];
            }
            else if (rayHit.transform == models[23])
            {
                return models[23];
            }
            else if (rayHit.transform == models[24])
            {
                return models[24];
            }
            else if (rayHit.transform == models[25])
            {
                return models[25];
            }
            else if (rayHit.transform == models[26])
            {
                return models[26];
            }
            else if (rayHit.transform == models[27])
            {
                return models[27];
            }
            else if (rayHit.transform == models[28])
            {
                return models[28];
            }
            else if (rayHit.transform == models[29])
            {
                return models[29];
            }
            else if (rayHit.transform == models[30])
            {
                return models[30];
            }
            else if (rayHit.transform == models[31])
            {
                return models[31];
            }
            else if (rayHit.transform == models[32])
            {
                return models[32];
            }
            else if (rayHit.transform == models[33])
            {
                return models[33];
            }
            else if (rayHit.transform == models[34])
            {
                return models[34];
            }
            else if (rayHit.transform == models[35])
            {
                return models[35];
            }
            else if (rayHit.transform == models[36])
            {
                return models[36];
            }


            #endregion


        }

        return currentModel;
	}

	// sets the world position of the current model
	private bool SetModelWorldPos(Vector3 vNewPos, Quaternion qNewRot)
	{
		if(currentModel)
		{
			// set position and look at the camera
			currentModel.position = vNewPos;
			currentModel.rotation = qNewRot;

			//if (modelLookingAtCamera) 
			//{
			//	//Camera arCamera = arManager.GetMainCamera();
			////	MultiARInterop.TurnObjectToCamera(currentModel.gameObject, arCamera, currentModel.position, currentModel.up);
			//}

			return true;
		}

		return false;
	}

	// removes the model anchor
	private bool RemoveModelAnchor(Transform model)
	{
		// remove the anchor
		if(model && arManager)
		{
			// get the anchorId
			string anchorId = arManager.GetObjectAnchorId(model.gameObject);

			if(anchorId != string.Empty)
			{
				arManager.RemoveGameObjectAnchor(anchorId, false);
				return true;
			}
		}

		return false;
	}

	// turn off the toggle, of model is missing or inactive
	private void UpdateToggleStatus(Toggle toggle, Transform model)
	{
		if(toggle && toggle.isOn)
		{
			if(model == null || !model.gameObject.activeSelf)
			{
				toggle.isOn = false;
			}
		}
	}

    // returns the 1st active model
    private Transform GetActiveModel()
    {
        if (models[0] && models[0].gameObject.activeSelf)
            return models[0];
        else if (models[1] && models[1].gameObject.activeSelf)
            return models[1];
        else if (models[2] && models[2].gameObject.activeSelf)
            return models[2];
        else if (models[3] && models[3].gameObject.activeSelf)
            return models[3];
        else if (models[4] && models[4].gameObject.activeSelf)
            return models[4];
        else if (models[5] && models[5].gameObject.activeSelf)
            return models[5];
        else if (models[6] && models[6].gameObject.activeSelf)
            return models[6];
        else if (models[7] && models[7].gameObject.activeSelf)
            return models[7];
        else if (models[8] && models[8].gameObject.activeSelf)
            return models[8];
        else if (models[9] && models[9].gameObject.activeSelf)
            return models[9];
        else if (models[10] && models[10].gameObject.activeSelf)
            return models[10];
        else if (models[11] && models[11].gameObject.activeSelf)
            return models[11];

        else if (models[12] && models[12].gameObject.activeSelf)
            return models[12];
        else if (models[13] && models[13].gameObject.activeSelf)
            return models[13];
        else if (models[14] && models[14].gameObject.activeSelf)
            return models[14];
        else if (models[15] && models[15].gameObject.activeSelf)
            return models[15];
        else if (models[16] && models[16].gameObject.activeSelf)
            return models[16];
        else if (models[17] && models[17].gameObject.activeSelf)
            return models[17];
        else if (models[18] && models[18].gameObject.activeSelf)
            return models[18];
        else if (models[19] && models[19].gameObject.activeSelf)
            return models[19];
        else if (models[20] && models[20].gameObject.activeSelf)
            return models[20];
        else if (models[21] && models[21].gameObject.activeSelf)
            return models[21];
        else if (models[22] && models[22].gameObject.activeSelf)
            return models[22];
        else if (models[23] && models[23].gameObject.activeSelf)
            return models[23];
        else if (models[24] && models[24].gameObject.activeSelf)
            return models[24];
        else if (models[25] && models[25].gameObject.activeSelf)
            return models[25];
        else if (models[26] && models[26].gameObject.activeSelf)
            return models[26];
        else if (models[27] && models[27].gameObject.activeSelf)
            return models[27];
        else if (models[28] && models[28].gameObject.activeSelf)
            return models[28];
        else if (models[29] && models[29].gameObject.activeSelf)
            return models[29];
        else if (models[30] && models[30].gameObject.activeSelf)
            return models[30];
        else if (models[31] && models[31].gameObject.activeSelf)
            return models[31];
        else if (models[32] && models[32].gameObject.activeSelf)
            return models[32];
        else if (models[33] && models[33].gameObject.activeSelf)
            return models[33];
        else if (models[34] && models[34].gameObject.activeSelf)
            return models[34];
        else if (models[35] && models[35].gameObject.activeSelf)
            return models[35];
        else if (models[36] && models[36].gameObject.activeSelf)
            return models[36];

        // no model is currently selected
        return null;
	}


    // invoked by the 1st toggle
    #region modelados
    public void Modelado1(bool bOn)
	{
        int numero = 0;
		if(models[numero])
		{
			if(!bOn)
			{
				// remove the world anchor
				RemoveModelAnchor(models[numero]);
			}

			// activate or deactivate the object
			models[numero].gameObject.SetActive(bOn);

			if(bOn)
			{
				// make it currently selected
				currentModel = models[numero];
              //  anim.SetBool("UpOrDown", true);       
			}
			else if(currentModel == models[numero])
			{
				// if it was selected, reset the selection
				currentModel = GetActiveModel();
			}
		}
	}
    public void Modelado2(bool bOn)
    {
        int numero = 1;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
               // anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado3(bool bOn)
    {
        int numero = 2;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
              //  anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado4(bool bOn)
    {
        int numero = 3;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                // anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado5(bool bOn)
    {
        int numero = 4;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];

                //  anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado6(bool bOn)
    {
        int numero = 5;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //    anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado7(bool bOn)
    {
        int numero = 6;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //    anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado8(bool bOn)
    {
        int numero = 7;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //  anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado9(bool bOn)
    {
        int numero = 8;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //  anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado10(bool bOn)
    {
        int numero = 9;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                // anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado11(bool bOn)
    {
        int numero = 10;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado12(bool bOn)
    {
        int numero = 11;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //  anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado13(bool bOn)
    {
        int numero = 12;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado14(bool bOn)
    {
        int numero = 13;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //    anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado15(bool bOn)
    {
        int numero = 14;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado16(bool bOn)
    {
        int numero = 15;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado17(bool bOn)
    {
        int numero = 16;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado18(bool bOn)
    {
        int numero = 17;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado19(bool bOn)
    {
        int numero = 18;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado20(bool bOn)
    {
        int numero = 19;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //  anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado21(bool bOn)
    {
        int numero = 20;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado22(bool bOn)
    {
        int numero = 21;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado23(bool bOn)
    {
        int numero = 22;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado24(bool bOn)
    {
        int numero = 23;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado25(bool bOn)
    {
        int numero = 24;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //  anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado26(bool bOn)
    {
        int numero = 25;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado27(bool bOn)
    {
        int numero = 26;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //     anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado28(bool bOn)
    {
        int numero = 27;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //    anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado29(bool bOn)
    {
        int numero = 28;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado30(bool bOn)
    {
        int numero = 29;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //    anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado31(bool bOn)
    {
        int numero = 30;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //     anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado32(bool bOn)
    {
        int numero = 31;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado33(bool bOn)
    {
        int numero = 32;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado34(bool bOn)
    {
        int numero = 33;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //  anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado35(bool bOn)
    {
        int numero = 34;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //   anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado36(bool bOn)
    {
        int numero = 35;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //    anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }
    public void Modelado37(bool bOn)
    {
        int numero = 36;
        if (models[numero])
        {
            if (!bOn)
            {
                // remove the world anchor
                RemoveModelAnchor(models[numero]);
            }

            // activate or deactivate the object
            models[numero].gameObject.SetActive(bOn);

            if (bOn)
            {
                // make it currently selected
                currentModel = models[numero];
                //    anim.SetBool("UpOrDown", true);
            }
            else if (currentModel == models[numero])
            {
                // if it was selected, reset the selection
                currentModel = GetActiveModel();
            }
        }
    }

    #endregion
}



