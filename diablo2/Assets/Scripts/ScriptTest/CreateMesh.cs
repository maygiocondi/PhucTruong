using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMesh : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    var meshFilter = GetComponent<MeshFilter>();
    var meshRenderer = GetComponent<MeshRenderer>();

    var mesh = new Mesh();

    Vector3[] vertices = new Vector3[]
    {
           Vector3.zero, Vector3.right, Vector3.up

  };

    mesh.vertices = vertices;

    int[] triangles = new int[]
    {
      0,2,1
    };


    mesh.normals = new Vector3[] {
      Vector3.back, Vector3.back, Vector3.back
    };
    meshFilter.mesh = mesh;
    mesh.triangles = triangles;

    mesh.uv = new Vector2[] {
      Vector2.zero, Vector2.right, Vector2.up
    };
  }


}
