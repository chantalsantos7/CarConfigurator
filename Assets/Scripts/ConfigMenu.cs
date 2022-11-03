using Assets.Scripts.Enumeration;
using Assets.Scripts.Vehicles;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConfigMenu : MonoBehaviour
{
    public List<GameObject> vehicles;
    public Vehicle selectedVehicle;
    public TMP_Dropdown ColourDropdown;
    public TMP_Dropdown WheelDropdown;
    public TMP_Dropdown EngineDropdown;
    public TMP_Dropdown LeatherDropdown;
    public TMP_Text ModelName;
    public TMP_Text PriceText;
    public TMP_Text FinalModel;
    public TMP_Text FinalPrice;
    public TMP_Text FinalColour;
    public TMP_Text FinalWheels;
    public TMP_Text FinaleEngine;
    public TMP_Text FinalInterior;
    public AudioSource BgMusicSource;
    
    private bool rotationPaused = false;
    private bool musicPaused = false;
    
    float TotalPrice;
    int selectedVehicleIndex = 0;

    void Start()
    {
        PopulateUI();
    }

    public void LeftSwitch()
    {
        vehicles[selectedVehicleIndex].SetActive(false);
        selectedVehicleIndex--;

        if (selectedVehicleIndex < 0)
        {
            selectedVehicleIndex = vehicles.Count - 1;
        }

        vehicles[selectedVehicleIndex].SetActive(true);
        selectedVehicle = vehicles[selectedVehicleIndex].GetComponent<Vehicle>();
        PopulateUI();
        ChangeVehicleColour();
    }

    public void RightSwitch()
    {
        vehicles[selectedVehicleIndex].SetActive(false);
        selectedVehicleIndex++;

        if (selectedVehicleIndex > vehicles.Count - 1)
        {
            selectedVehicleIndex = 0;
        }

        vehicles[selectedVehicleIndex].SetActive(true);
        selectedVehicle = vehicles[selectedVehicleIndex].GetComponent<Vehicle>();
        PopulateUI();
        ChangeVehicleColour();
    }

    public void PopulateUI()
    {
        UpdateName();
        LoadDropdowns(ColourDropdown, selectedVehicle.possColours);
        LoadDropdowns(WheelDropdown, selectedVehicle.wheelTypes);
        LoadDropdowns(EngineDropdown, selectedVehicle.engineTypes);
        LoadDropdowns(LeatherDropdown, selectedVehicle.leatherTypes);
        UpdatePrice();
    }

    public void LoadDropdowns<T>(TMP_Dropdown dropdownMenu, List<T> possibleItems)
    {
        dropdownMenu.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new();
        for (int i = 0; i < possibleItems.Count; i++)
        {
            options.Add(new TMP_Dropdown.OptionData(possibleItems[i].ToString()));
        }
        dropdownMenu.AddOptions(options);
    }

    public void ChangeVehicleColour()
    {
        if (selectedVehicle is RaceCar race)
        {
            race.ChangeColour(ColourDropdown.value);
        }
        else if (selectedVehicle is RetroCar retro)
        {
            retro.ChangeColour(ColourDropdown.value);
        }
    }

    public void UpdateName()
    {
        ModelName.text = selectedVehicle.GetMake();
    }

    public float PriceCheck(TMP_Dropdown dropdown, Dictionary<string, float> priceDict)
    {
        string key = dropdown.options[dropdown.value].text;
        return priceDict[key];
    }

    public void UpdatePrice()
    {
        TotalPrice = selectedVehicle.basePrice;
        TotalPrice += PriceCheck(EngineDropdown, EngineProperties.EnginePrices);
        TotalPrice += PriceCheck(WheelDropdown, WheelsProperties.WheelPrices);
        TotalPrice += PriceCheck(LeatherDropdown, LeatherProperties.LeatherPrices);
        PriceText.text = "Total Price: £" + TotalPrice;
    }

    public void PauseButton()
    {
        if (rotationPaused)
        {
            selectedVehicle.UnpauseRotation();
            rotationPaused = false;
        } else
        {
            rotationPaused = true;
            selectedVehicle.PauseRotation();
        }
    }

    public void BgMusicButton()
    {
        if (musicPaused)
        {
            BgMusicSource.Play();
            musicPaused = false;
        } else
        {
            musicPaused = true;
            BgMusicSource.Pause();
        }
    }

    public void Checkout()
    {
        FinalModel.text = selectedVehicle.GetMake();
        FinalColour.text = "Colour: " + ColourDropdown.options[ColourDropdown.value].text;
        FinaleEngine.text = "Engine: " + EngineDropdown.options[EngineDropdown.value].text;
        FinalWheels.text = "Wheel: " + WheelDropdown.options[WheelDropdown.value].text;
        FinalInterior.text = "Interior Leather: " + LeatherDropdown.options[LeatherDropdown.value].text;
        FinalPrice.text = "Price: £" + TotalPrice;
        
    }
}
