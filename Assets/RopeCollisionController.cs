using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

[RequireComponent(typeof(ObiSolver))]
public class RopeCollisionController : MonoBehaviour
{
    ObiSolver solver;
    ObiSolver.ObiCollisionEventArgs collisionEvent;

    void Awake()
    {
        solver = this.GetComponent<ObiSolver>();
    }

    void OnEnable()
    {
        solver.OnCollision += Solver_OnCollision;
    }

    void OnDisable()
    {
        solver.OnCollision -= Solver_OnCollision;
    }

    void Solver_OnCollision(object sender, Obi.ObiSolver.ObiCollisionEventArgs e)
    {
        var world = ObiColliderWorld.GetInstance();
        foreach (Oni.Contact contact in e.contacts)
        {
            // this one is an actual collision:
            if (contact.distance < 0.01)
            {
                ObiColliderBase col = world.colliderHandles[contact.bodyB].owner;

                if (col != null && col.gameObject.CompareTag("Enemy2"))
                {
                    //Debug.Log("A");
                    col.gameObject.GetComponent<Enemy2Controller>().ropeCollision = true;
                }

                // if this collider is tagged as "zero gravity":
                if (col != null && col.gameObject.CompareTag("Hitbox"))
                {
                    //Debug.Log("A");
                    col.transform.parent.gameObject.GetComponent<BasicEnemyController>().hitbox1 = true;
                }

                if (col != null && col.gameObject.CompareTag("Hitbox2"))
                {
                    //Debug.Log("A");
                    col.transform.parent.gameObject.GetComponent<BasicEnemyController>().hitbox2 = true;
                }

                if (col != null && col.gameObject.CompareTag("Hitbox3"))
                {
                    //Debug.Log("A");
                    col.transform.parent.gameObject.GetComponent<BasicEnemyController>().hitbox3 = true;
                }

                if (col != null && col.gameObject.CompareTag("Hitbox4"))
                {
                    //Debug.Log("A");
                    col.transform.parent.gameObject.GetComponent<BasicEnemyController>().hitbox4 = true;
                }
            }
        }
    }
}
