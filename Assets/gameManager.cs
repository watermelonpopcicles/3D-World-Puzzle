using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Sprite[] countrySprites;

    private string[] countries = new string[] { "Albania", "Andorra", "Armenia", "Austria", "Azerbaijan", "Belarus", "Belgium", "Bosnia and Herzegovina", "Bulgaria", "Croatia", "Cyprus", "Czech Rep.", "Denmark", "Estonia", "Finland", "France", "Georgia", "Germany", "Greece", "Hungary", "Iceland", "Ireland", "Italy", "Kazakhstan", "Kosovo", "Latvia", "Liechtenstein", "Lithuania", "Luxembourg", "Malta", "Moldova", "Monaco", "Montenegro", "Netherlands", "North Macedonia", "Norway", "Poland", "Portugal", "Romania", "Russia", "San Marino", "Serbia", "Slovakia", "Slovenia", "Spain", "Sweden", "Switzerland", "Turkey", "Ukraine", "United Kingdom", "Vatican City" };
    public string[] randomCountries;
    public string selectedCountry;
    private int index;
    public bool startGame;
    public Text countryToDisplay;
    public Image countryPicture;
    private bool shuffled;
    private bool setupPicture;
    public bool voiceDone;
    public Animator pictureAnimatorController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startGame) // checking game if started
        {
            shuffled = false;
            randomCountries = new string[countries.Length ];
            startGame = false;

            for (int i = 0; i < countries.Length; i++)
            {

                while (true)
                {
                    int rnum = Random.Range(0, countries.Length);

                    string rcountry = countries[rnum];
                    bool found = false;
                    for (int j = 0; j < randomCountries.Length; j++)
                    {
                        if (randomCountries[j] == rcountry)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found != true)
                    {

                        randomCountries[i] = rcountry;
                        break;
                    }
                }
            }
            shuffled = true;
            setupPicture = true;

        }
        if (shuffled && setupPicture) {
            setupPicture = false;
            countryToDisplay.text = randomCountries[index];
            int spriteOrder = 0;
            foreach (string country in countries) {
                if (country == randomCountries[index]) {
                    break;
                }
                spriteOrder++;
            }
            countryPicture.sprite = countrySprites[spriteOrder];
            int countryRotate = Random.Range(0, 3);
            Vector3 temp = countryPicture.transform.localEulerAngles;

            if (countryRotate == 0) {
                temp.z = 0;
            }
            if (countryRotate == 1)
            {
                temp.z = 90;
            }
            if (countryRotate == 2)
            {
                temp.z = 180;
            }
            if (countryRotate == 3)
            {
                temp.z = 270;
            }


            countryPicture.transform.localEulerAngles = temp;

            //play voice sound
           

        }
        if (voiceDone)
        {
            voiceDone = false;
            pictureAnimatorController.SetBool("animationTrigger", true);
        }
    }
}
