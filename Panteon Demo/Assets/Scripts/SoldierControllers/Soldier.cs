using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour, ISolderSkill
{
    //////////////////       Later Received       /////////////////
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask damageableLayers;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    private bool _isMoving = false;
    private bool _isClicked = false;
    private Vector3 _target;
    RaycastHit2D hit;

    //////////////////       Received from Soldier Data Scriptable Object      /////////////////
    [SerializeField] private SoldierData soldierData = null;
    private string _soldierType = null;
    public string SoldierType => _soldierType;
    private int _health;
    int _currentHealth;
    private int _attackDamage;
    private float _soldierSpeed;

    #region Awake           ////Caching
    private void Awake()
    {
        GetComponentInChildren<SpriteRenderer>().color = soldierData.soldierColor;
        _health = soldierData.soldierHealth;
        _attackDamage = soldierData.attackDamage;
        _soldierSpeed = soldierData.soldierSpeed;

        // transform.localScale = soldierData.soldierScale;     // May be we can use scale   
        // _soldierType = soldierData.soldierType;             // Checking soldierType 
    }

    #endregion

    private void Start() {  /// Set first health 
        _currentHealth = _health;
        GameEvents.Instance.onSoldierTriggerEnter += Attack;
    }

    private void Update() {  //// Touch the screen and Soldier Movement //  Left Click:Selection, Right Click: Attack and Movement


        _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _target.z = transform.position.z;
        
        if (Input.GetMouseButtonDown(0))  
        {

            GetComponentInChildren<SpriteRenderer>().color = soldierData.soldierColor;

            hit = Physics2D.Raycast(_target, Vector2.zero);
        
            if (hit.collider.gameObject.tag == "Soldier")
            {
                animator = hit.collider.gameObject.GetComponent<Animator>();
                //animator.SetFloat("Speed", 0);
            }
            animator.SetFloat("Speed", 0);
        }

        if (Input.GetMouseButtonDown(1))
        {

            if (hit.collider.gameObject.tag == "Soldier")        
            {
                Move(hit.collider.gameObject);
                _isClicked = true;
                _isMoving = true;

                /*if (Time.time >= nextAttackTime)   /// Maybe adding Soldier attack frequency   
                {
                    //Attack();
                    //OnDestroy();
                    nextAttackTime = Time.time + 1f / attackRate;
                }*/
            }
        }
    }

    public void Attack()  //// Soldiers attack skill  (inherited from interface)  
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,damageableLayers);

        foreach (Collider2D obj in hitObjects){

            if (obj.CompareTag("Soldier"))
                obj.GetComponent<Soldier>().TakeDamage(_attackDamage);

            else if (obj.CompareTag("Building"))
                obj.GetComponent<Building>().TakeDamage(_attackDamage);

            //Debug.Log("We hit: " + obj.name);
        }
    }
    public void TakeDamage(int damage){  /// Check the soldier health

        _currentHealth -= damage;

        if(_currentHealth <= 0){
            Dead();
        }
    }

    public void Dead()  /// Destroy the  soldier  (inherited from interface)
    {
        Debug.Log("Soldier died!");

        Destroy(gameObject);
    }

    public void Move(GameObject obj) /// Soldiers movement skill (inherited from interface)
    {
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, _target, _soldierSpeed * Time.deltaTime);

        if (obj.transform.position == _target)
        {
            _isMoving = false;
            _isClicked = false;
        }
        obj.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        obj.GetComponent<Animator>().SetFloat("Speed",_soldierSpeed);
    }
     /// <summary>
    /// Callback to draw gizmos only if the object is selected.
    /// </summary>
    void OnDrawGizmosSelected() /// Draw the collision detection area on editor
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void OnDestroy(){  /// Events are destroy
        //Debug.Log("");
        GameEvents.Instance.onSoldierTriggerEnter -= Attack;
    }

}
