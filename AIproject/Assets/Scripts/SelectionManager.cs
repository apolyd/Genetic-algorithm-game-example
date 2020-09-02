using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string SelectableTag = "Selectable";
    [SerializeField] private Material HighlightedMaterial;
    public GameObject Player;
    public GameObject cameraLaptop;
    public GameObject spawner;
    public GameObject CreateNewSlimeobj;
    public GameObject PauseText;
    public bool leftMouseClicked;  //check mouse buttons
    public bool rightMouseClicked;
    public bool parent1Selected;  //check if we selected parents
    public bool parent2Selected;
    private Material DefaultMaterial; //save the last material there
    private Transform _selection;
    private int flag = 0;
    public bool flagPause = false;

    // Start is called before the first frame update
    void Start()
    {
        leftMouseClicked = false;
        rightMouseClicked = false;
        parent1Selected = false;
        parent2Selected = false;
        PauseText.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space")) //pause time 
        {
            if (flagPause == false)
            {
                flagPause = true;
                Time.timeScale = 0f;
                PauseText.SetActive(true);
            }
            else
            {
                flagPause = false;
                Time.timeScale = 1f;
                PauseText.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))  //get out of laptop sequence
        {
            Player.SetActive(true);
            cameraLaptop.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
           
        }
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            var selectionLabel = _selection.GetChild(0).GetComponent<LabelPopUp>().nameLabel;
            selectionRenderer.material = DefaultMaterial;
            selectionLabel.SetActive(false);
            _selection = null;
        }

        if (Input.GetMouseButtonDown(1)) //check if left mouse is clicked
        {
            rightMouseClicked = true;
        }
        else
        {
            rightMouseClicked = false;
        }

        if (Input.GetMouseButtonDown(0)) //check if left mouse is clicked
        {
            leftMouseClicked = true;
        }
        else
        {
            leftMouseClicked = false;
        }


        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 7f))
        {
            var selection = hit.transform;

            if (selection.CompareTag("Slime") && CreateNewSlimeobj.GetComponent<CreateNewSlime>().PlayerClicked == false)
            {
                if (leftMouseClicked)
                {
;                    parent1Selected = true;     //add the parent1
                     spawner.GetComponent<CreateNewSlime>().addParent(selection.GetComponent<CreatureAI>().foodGene, selection.GetComponent<CreatureAI>().waterGene, selection.GetComponent<CreatureAI>().temperatureGene, selection.GetComponent<CreatureAI>().lightGene, selection.GetComponent<CreatureAI>().hygieneGene, selection.GetComponent<CreatureAI>().deathDecayGene,1);
                     //parent1Selected = true;
                }
                if (rightMouseClicked)
                {
                    parent2Selected = true;     //add the parent2
                    spawner.GetComponent<CreateNewSlime>().addParent(selection.GetComponent<CreatureAI>().foodGene, selection.GetComponent<CreatureAI>().waterGene, selection.GetComponent<CreatureAI>().temperatureGene, selection.GetComponent<CreatureAI>().lightGene, selection.GetComponent<CreatureAI>().hygieneGene, selection.GetComponent<CreatureAI>().deathDecayGene, 2);
                  //  parent2Selected = true;
                }
            }
            if (selection.CompareTag(SelectableTag))
            {
                selection.GetChild(0).GetComponent<LabelPopUp>().nameLabel.SetActive(true); //enable label
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    if(flag == 0 || selectionRenderer.material!=HighlightedMaterial)
                    {
                        DefaultMaterial = selectionRenderer.material;
                        flag = 1;
                    }
                    selectionRenderer.material = HighlightedMaterial;
                }
                _selection = selection;

                //Select the laptop here
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Player.SetActive(false);
                    cameraLaptop.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }

                

            }
            else
            {
                flag = 0;
            }
            
        }

        
    }
}
