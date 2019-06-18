using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ExpressionSolver : MonoBehaviour
{
    [Header("Tutorial")]
    public bool tutorial = false;
    public DialogTrigger dialog;

    public CallerCard caller;

    public TextMeshPro textMesh;
    // Start is called before the first frame update

    public int SolveExpression()
    {
        if(caller == null) {
            textMesh.text = "Clr";
            return 0;
        }
        string ex = caller.GetExpression();

        if (ex[0] == 'b' && ex[ex.Length  - 1] == '=') {
            string sub = ex.Substring(1, ex.Length - 2);

            var numberStrings = sub.Split('+');

            List<int> numbers =  new List<int>();
            foreach(string s in numberStrings) {
                int i = 0;
                Int32.TryParse(s, out i);
                numbers.Add(i);
            }

            int result = 0;
            foreach(int i in numbers) {
                result += i;
            }
            
            textMesh.text = result.ToString();
            if (tutorial) {
                if(result == 3) {
                    dialog.Trigger();
                }
            }
            return result;
            
        } else {
            textMesh.text = "ERR";
            return 0;
        }
    }
    
    public void CheckResult()
    {
        if (SolveExpression() == caller.GetGoal()) {
            caller.Solve();
        } else {
            textMesh.text = "INCORR";
        }
    }
}
