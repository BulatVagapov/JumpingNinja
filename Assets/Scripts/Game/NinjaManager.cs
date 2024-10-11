using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaManager : MonoBehaviour
{
    private List<Ninja> ninjas = new();

    private OpenedNinjasArrayForSave openedNinjas;

    [SerializeField] private Transform ninjaSpawnPositiontransform;
    [SerializeField] private Transform ninjaParent;

    private Ninja chosenNinja;

    public Ninja ChosenNinja => chosenNinja;
    public OpenedNinjasArrayForSave OpenedNinjas => openedNinjas;

    public static NinjaManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            Instance = this;
        }
        else
        {
            Instance = this;
        }

        string savedString = PlayerPrefs.GetString("OpenedNinjas");
       
        openedNinjas = JsonUtility.FromJson<OpenedNinjasArrayForSave>(savedString);

        if(openedNinjas == null)
        {
            openedNinjas = new OpenedNinjasArrayForSave();
        } 
    }

    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            chosenNinja = Instantiate(Resources.Load<Ninja>("Ninjas/Ninja_" + i), transform);
            chosenNinja.gameObject.SetActive(false);

            ninjas.Add(chosenNinja);
        }

        SetChoosenNinja();
    }

    public void ChoseNewNinja(int index)
    {
        chosenNinja.StopNinja();
        chosenNinja.transform.parent = transform;
        chosenNinja.gameObject.SetActive(false);

        openedNinjas.ChosenNinjaIndex = index;

        SetChoosenNinja();
    }

    private void SetChoosenNinja()
    {
        chosenNinja = ninjas[openedNinjas.ChosenNinjaIndex];
        chosenNinja.transform.parent = ninjaParent;
        chosenNinja.transform.position = ninjaSpawnPositiontransform.position;
        chosenNinja.gameObject.SetActive(true);
    }

    public void RestartNinja()
    {
        chosenNinja.transform.position = ninjaSpawnPositiontransform.position;
    }

    public void SaveOpenedNinjas()
    {
        PlayerPrefs.SetString("OpenedNinjas", JsonUtility.ToJson(openedNinjas));
    }
}
