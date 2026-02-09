using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    void Start()
    {
        GeneratePlain();
        GenerateCabin();
        GenerateTrees();
    }

    void GeneratePlain()
    {
        GameObject plain = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plain.name = "Plain";
        plain.transform.position = Vector3.zero;
        plain.transform.localScale = new Vector3(50f, 1f, 50f);
        
        Material plainMaterial = new Material(Shader.Find("Unlit/Color"));
        plainMaterial.color = new Color(0.3f, 0.5f, 0.2f);
        plain.GetComponent<Renderer>().material = plainMaterial;
    }

    void GenerateCabin()
    {
        GameObject cabin = new GameObject("Cabin");
        cabin.transform.position = Vector3.zero;

        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.name = "Floor";
        floor.transform.parent = cabin.transform;
        floor.transform.localPosition = new Vector3(0f, 0.1f, 0f);
        floor.transform.localScale = new Vector3(8f, 0.2f, 6f);
        Material floorMaterial = new Material(Shader.Find("Unlit/Color"));
        floorMaterial.color = new Color(0.4f, 0.3f, 0.2f);
        floor.GetComponent<Renderer>().material = floorMaterial;

        Material wallMaterial = new Material(Shader.Find("Unlit/Color"));
        wallMaterial.color = new Color(0.5f, 0.35f, 0.2f);

        GameObject backWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        backWall.name = "Back Wall";
        backWall.transform.parent = cabin.transform;
        backWall.transform.localPosition = new Vector3(0f, 2f, -3f);
        backWall.transform.localScale = new Vector3(8f, 3.8f, 0.2f);
        backWall.GetComponent<Renderer>().material = wallMaterial;

        CreateWallSection("Front Wall Left", cabin.transform, new Vector3(-2.25f, 2f, 3f), new Vector3(3.5f, 3.8f, 0.2f), wallMaterial);
        CreateWallSection("Front Wall Right", cabin.transform, new Vector3(2.25f, 2f, 3f), new Vector3(3.5f, 3.8f, 0.2f), wallMaterial);
        CreateWallSection("Front Wall Top", cabin.transform, new Vector3(0f, 2.9f, 3f), new Vector3(1f, 1.8f, 0.2f), wallMaterial);

        CreateWallSection("Left Wall Bottom", cabin.transform, new Vector3(-4f, 0.9f, 0f), new Vector3(0.2f, 1.6f, 6f), wallMaterial);
        CreateWallSection("Left Wall Top", cabin.transform, new Vector3(-4f, 3.3f, 0f), new Vector3(0.2f, 1.2f, 6f), wallMaterial);
        CreateWallSection("Left Wall Front", cabin.transform, new Vector3(-4f, 2.2f, -1.3f), new Vector3(0.2f, 1f, 3.4f), wallMaterial);
        CreateWallSection("Left Wall Back", cabin.transform, new Vector3(-4f, 2.2f, 2.3f), new Vector3(0.2f, 1f, 1.4f), wallMaterial);

        CreateWallSection("Right Wall Bottom", cabin.transform, new Vector3(4f, 0.9f, 0f), new Vector3(0.2f, 1.6f, 6f), wallMaterial);
        CreateWallSection("Right Wall Top", cabin.transform, new Vector3(4f, 3.3f, 0f), new Vector3(0.2f, 1.2f, 6f), wallMaterial);
        CreateWallSection("Right Wall Front", cabin.transform, new Vector3(4f, 2.2f, -1.3f), new Vector3(0.2f, 1f, 3.4f), wallMaterial);
        CreateWallSection("Right Wall Back", cabin.transform, new Vector3(4f, 2.2f, 2.3f), new Vector3(0.2f, 1f, 1.4f), wallMaterial);

        GameObject roof = GameObject.CreatePrimitive(PrimitiveType.Cube);
        roof.name = "Roof";
        roof.transform.parent = cabin.transform;
        roof.transform.localPosition = new Vector3(0f, 4f, 0f);
        roof.transform.localScale = new Vector3(8.5f, 0.3f, 6.5f);
        Material roofMaterial = new Material(Shader.Find("Unlit/Color"));
        roofMaterial.color = new Color(0.3f, 0.2f, 0.15f);
        roof.GetComponent<Renderer>().material = roofMaterial;
    }

    void CreateWallSection(string name, Transform parent, Vector3 localPosition, Vector3 localScale, Material material)
    {
        GameObject wallSection = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wallSection.name = name;
        wallSection.transform.parent = parent;
        wallSection.transform.localPosition = localPosition;
        wallSection.transform.localScale = localScale;
        wallSection.GetComponent<Renderer>().material = material;
    }

    void GenerateTrees()
    {
        GameObject treesParent = new GameObject("Trees");
        
        Vector3[] treePositions = new Vector3[]
        {
            new Vector3(15f, 0f, 20f),
            new Vector3(-20f, 0f, 15f),
            new Vector3(25f, 0f, -10f),
            new Vector3(-15f, 0f, -25f),
            new Vector3(30f, 0f, 5f),
            new Vector3(-30f, 0f, -5f),
            new Vector3(10f, 0f, -20f),
            new Vector3(-25f, 0f, 20f),
            new Vector3(18f, 0f, -15f),
            new Vector3(-18f, 0f, 10f),
            new Vector3(35f, 0f, 30f),
            new Vector3(-35f, 0f, -30f),
            new Vector3(40f, 0f, -20f),
            new Vector3(-40f, 0f, 25f),
            new Vector3(12f, 0f, 35f)
        };

        for (int i = 0; i < treePositions.Length; i++)
        {
            CreateTree(treePositions[i], treesParent.transform, i);
        }
    }

    void CreateTree(Vector3 position, Transform parent, int index)
    {
        GameObject tree = new GameObject($"Tree_{index}");
        tree.transform.parent = parent;
        tree.transform.position = position;

        GameObject trunk = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        trunk.name = "Trunk";
        trunk.transform.parent = tree.transform;
        trunk.transform.localPosition = new Vector3(0f, 3f, 0f);
        trunk.transform.localScale = new Vector3(0.5f, 3f, 0.5f);
        Material trunkMaterial = new Material(Shader.Find("Unlit/Color"));
        trunkMaterial.color = new Color(0.4f, 0.25f, 0.15f);
        trunk.GetComponent<Renderer>().material = trunkMaterial;

        GameObject leaves = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        leaves.name = "Leaves";
        leaves.transform.parent = tree.transform;
        leaves.transform.localPosition = new Vector3(0f, 7.5f, 0f);
        leaves.transform.localScale = new Vector3(4f, 4f, 4f);
        Material leavesMaterial = new Material(Shader.Find("Unlit/Color"));
        leavesMaterial.color = new Color(0.2f, 0.6f, 0.2f);
        leaves.GetComponent<Renderer>().material = leavesMaterial;
    }

    void Update()
    {
        
    }
}
