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

        GameObject backWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        backWall.name = "Back Wall";
        backWall.transform.parent = cabin.transform;
        backWall.transform.localPosition = new Vector3(0f, 2f, -3f);
        backWall.transform.localScale = new Vector3(8f, 3.8f, 0.2f);
        Material wallMaterial = new Material(Shader.Find("Unlit/Color"));
        wallMaterial.color = new Color(0.5f, 0.35f, 0.2f);
        backWall.GetComponent<Renderer>().material = wallMaterial;

        GameObject frontWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        frontWall.name = "Front Wall";
        frontWall.transform.parent = cabin.transform;
        frontWall.transform.localPosition = new Vector3(0f, 2f, 3f);
        frontWall.transform.localScale = new Vector3(8f, 3.8f, 0.2f);
        Material wallMaterial2 = new Material(Shader.Find("Unlit/Color"));
        wallMaterial2.color = new Color(0.5f, 0.35f, 0.2f);
        frontWall.GetComponent<Renderer>().material = wallMaterial2;

        GameObject leftWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftWall.name = "Left Wall";
        leftWall.transform.parent = cabin.transform;
        leftWall.transform.localPosition = new Vector3(-4f, 2f, 0f);
        leftWall.transform.localScale = new Vector3(0.2f, 3.8f, 6f);
        Material wallMaterial3 = new Material(Shader.Find("Unlit/Color"));
        wallMaterial3.color = new Color(0.5f, 0.35f, 0.2f);
        leftWall.GetComponent<Renderer>().material = wallMaterial3;

        GameObject rightWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightWall.name = "Right Wall";
        rightWall.transform.parent = cabin.transform;
        rightWall.transform.localPosition = new Vector3(4f, 2f, 0f);
        rightWall.transform.localScale = new Vector3(0.2f, 3.8f, 6f);
        Material wallMaterial4 = new Material(Shader.Find("Unlit/Color"));
        wallMaterial4.color = new Color(0.5f, 0.35f, 0.2f);
        rightWall.GetComponent<Renderer>().material = wallMaterial4;

        GameObject roof = GameObject.CreatePrimitive(PrimitiveType.Cube);
        roof.name = "Roof";
        roof.transform.parent = cabin.transform;
        roof.transform.localPosition = new Vector3(0f, 4f, 0f);
        roof.transform.localScale = new Vector3(8.5f, 0.3f, 6.5f);
        Material roofMaterial = new Material(Shader.Find("Unlit/Color"));
        roofMaterial.color = new Color(0.3f, 0.2f, 0.15f);
        roof.GetComponent<Renderer>().material = roofMaterial;

        GameObject door = GameObject.CreatePrimitive(PrimitiveType.Cube);
        door.name = "Door";
        door.transform.parent = cabin.transform;
        door.transform.localPosition = new Vector3(0f, 1f, 3.05f);
        door.transform.localScale = new Vector3(1f, 2f, 0.1f);
        Material doorMaterial = new Material(Shader.Find("Unlit/Color"));
        doorMaterial.color = new Color(0.25f, 0.15f, 0.1f);
        door.GetComponent<Renderer>().material = doorMaterial;

        GameObject window1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        window1.name = "Window 1";
        window1.transform.parent = cabin.transform;
        window1.transform.localPosition = new Vector3(-4.05f, 2.2f, 1f);
        window1.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
        Material windowMaterial = new Material(Shader.Find("Unlit/Color"));
        windowMaterial.color = new Color(0.6f, 0.8f, 0.9f);
        window1.GetComponent<Renderer>().material = windowMaterial;

        GameObject window2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        window2.name = "Window 2";
        window2.transform.parent = cabin.transform;
        window2.transform.localPosition = new Vector3(4.05f, 2.2f, 1f);
        window2.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
        Material windowMaterial2 = new Material(Shader.Find("Unlit/Color"));
        windowMaterial2.color = new Color(0.6f, 0.8f, 0.9f);
        window2.GetComponent<Renderer>().material = windowMaterial2;
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
