//rule extraction code for all the modes in the Firewall game

using System;
using System.Collections.Generic;
class ExtractingRule {
    
    //Console.WriteLine("Hello World");
    //var random = new Random(); //using for random number generator
    
    public static List<string> returnValue = new List<string>(){} ;
    //for level 1 
    public static List<string> choice = new List<string>() {"color","shape"}; 
    
    //for level 2 easy mode 
    public static List<string> choiceLevel2Easy = new List<string>() {"color","numberEyes"};
    
    public static List<string> colors = new List<string>() { "red", "blue", "green" };
    public static List<string> shapes = new List<string>() { "Triangle", "Square", "Circle", "diamond", "star"};
    
    //level 2 easy mode. number of eyes
    public static List<string> numberOfEyes = new List<string>() { "one", "two", "three", "four"};
    
    //level 2 hard mode -> no of antennas and no of arms
    
    public static List<string> choiceLevel2Hard = new List<string>() {"color","numberEyes", "numberAntennas", "numberArms"};
    
    public static List<string> numberOfAntennas = new List<string>() {"oneAntenna", "twoAntenna", "threeAntenna", "fourAntenna"};
    public static List<string> numberOfArms = new List<string>() { "oneArm", "twoArm", "threeArm", "fourArm"};
    
    
    public static List<string> concatenated_color_shape = new List<string>() {};
    public static List<string> concatenated_color_shape_with_states = new List<string>(){};
    public static List<string> states = new List<string>() {"malicious_Blocked", "malicious_notBlocked", 
                                              "notmalicious_Blocked", "notmalicious_notBlocked"};
    public static List<string> rules_list = new List<string>() {};
    
    public static List<string> rules_list_with_states = new List<string>() {}; //will contain the final rules list

    
        //for level 1
        //in the easy mode we only have shapes -> so randomly pick one shape to be malicious and one to be blocked.
        
        
        //return type list of string
        //we only use shapes here
    	public List<string> Level1Easy()
        {
            //bool repeatCheck = false;
            List<string> results = new List<string>(){};
            var random = new Random(); //for randomization purpose
            
            int index = random.Next(shapes.Count); //for maliciousness
            string malicious = shapes[index];
            Console.WriteLine("Should only be malicious and not blocked: "+malicious);
            
            int index1 = random.Next(shapes.Count); //for blocked status
            
            foreach(var i in shapes)
            {
                if(index == index1)
                {
                    index1 = random.Next(shapes.Count);
                    continue;
                }
                else
                    break;
            }
            string blockedStatus = shapes[index1];
            Console.WriteLine("Should only be blocked & not malicious: "+blockedStatus);
            
            string malicious_and_blockestates = "";
            int index2 = random.Next(shapes.Count);
            
            foreach (var sh in shapes)
            {
            if(index2 == index1 | index2 == index)
                {
                    index2 = random.Next(shapes.Count);
                    continue;
                }
            else
                break;
                
            }
            
            
            malicious_and_blockestates = shapes[index2];
            Console.WriteLine("should be malicious and blocked: "+ malicious_and_blockestates);
            
            foreach (var j in shapes)
            {
                if(j == shapes[index])
                {
                    results.Add(j+"malicious_notBlocked");
                }
                else if(j == shapes[index1])
                {
                    results.Add(j+"notmalicious_Blocked");
                }
                else if (j == shapes[index2])
                {
                    results.Add(j+"malicious_Blocked");
                }
                else 
                    results.Add(j+"notmalicious_notBlocked");
            }
            
            Console.WriteLine("Level 1 Easy Mode Selected");
            return results;
        }

        //for level 1 hard Mode
        //in the hard mode we have shape and color. we would randomly pick one of them for maliciousness and other one to be blocked status    
        //first we are gonna choose if it's the color or the shape for maliciousness. Then we are gonna choose the value (could be color or shape based on the value from the first randomization)
        //same thing for the blocked status...
	    
	    //return type list of string
	    public List<string> Level1Hard()
        {
            List<string> results = new List<string>(){};
            string maliciousness = "";//for holding values of maliciousness
            string blockedStatus = "";
    
        //in the hard mode we have shape and color. we would randomly pick one of them for maliciousness and other one to be blocked status    
        //first we are gonna choose if it's the color or the shape for maliciousness. Then we are gonna choose the value (could be color or shape based on the value from the first randomization)
        //same thing for the blocked status...
        var random = new Random();
        int index = random.Next(choice.Count); //choosing for maliciousness
        Console.WriteLine("what did we choose to be malicious - "+choice[index]);    
            //choosing for maliciousness
            
            //if the choice is color
            if(choice[index] == "color")
                {   
                    Console.WriteLine("it chose color to be malicious");
                    int index1 = random.Next(colors.Count); //picking a random color for maliciousness
                    maliciousness = colors[index1]; //assigning the color
                    Console.WriteLine("The color which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The shape would determine blocked status");
                    int index2 = random.Next(shapes.Count); //random shape for blocked status
                    blockedStatus = shapes[index2];
                    Console.WriteLine("the shape should be Blocked: "+blockedStatus);
                    
                    foreach (var col in colors)
                    {
                      foreach (var sha in shapes)
                      {
                        if(col == maliciousness & sha == blockedStatus)
                        {
                            results.Add(col+sha+"malicious_Blocked");
                        }
                        else if(col == maliciousness)
                        {
                            results.Add(col+sha+"malicious_notBlocked");
                        }
                        else if(sha == blockedStatus)
                        {
                            results.Add(col+sha+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(col+sha+"notmalicious_notBlocked");
                        }
                      }
                    }
                }
            //if the choice is shape to be malicious    
            else 
                {
                    Console.WriteLine("It chose shape to be malicious");
                    int index1 = random.Next(shapes.Count);
                    maliciousness = shapes[index1];
                    Console.WriteLine("The shape which will be malicious: "+ maliciousness);
                    
                    Console.WriteLine("the color would determine the blocked status");
                    int index2 = random.Next(colors.Count); //random shape for blocked status
                    blockedStatus = colors[index2];
                    Console.WriteLine("the color that would be blocked: "+ blockedStatus);
                    
                    
                    foreach (var col in colors)
                    {
                      foreach (var sha in shapes)
                      {
                        if(col == blockedStatus & sha == maliciousness)
                        {
                            results.Add(col+sha+"malicious_Blocked");
                        }
                        else if(col == blockedStatus)
                        {
                            results.Add(col+sha+"notmalicious_Blocked");
                        }
                        else if(sha == maliciousness)
                        {
                            results.Add(col+sha+"malicious_notBlocked");
                        }
                        else 
                        {
                            results.Add(col+sha+"notmalicious_notBlocked");
                        }
                      }
					}
				}	
            
            Console.WriteLine("Level 1 hard Mode Selected");
        
            return results;            
                    
        } 
    
        //for level 2 
        //easy mode
            //color and number of eyes (instead of shapes, we have no. of eyes here)
    
        //in the easy mode we have shape and no of eyes. we would randomly pick one of them for maliciousness and other one to be blocked status    
        //first we are gonna choose if it's the color or the no. of eyes. Then we are gonna choose the value (could be color or no of eyes based on the value from the first randomization)
        //same thing for the blocked status...
	    
	    //return type list of string
	    public List<string> Level2Easy()
        {
            List<string> results = new List<string>(){};
            string maliciousness = "";//for holding values of maliciousness
            string blockedStatus = "";
    
        //in the hard mode we have shape and color. we would randomly pick one of them for maliciousness and other one to be blocked status    
        //first we are gonna choose if it's the color or the shape for maliciousness. Then we are gonna choose the value (could be color or shape based on the value from the first randomization)
        //same thing for the blocked status...
        var random = new Random();
        int index = random.Next(choiceLevel2Easy.Count); //choosing for maliciousness
        Console.WriteLine("what did we choose to be malicious - "+choiceLevel2Easy[index]);    
            //choosing for maliciousness
            
            //if the choice is color
            if(choiceLevel2Easy[index] == "color")
                {   
                    Console.WriteLine("it chose color to be malicious");
                    int index1 = random.Next(colors.Count); //picking a random color for maliciousness
                    maliciousness = colors[index1]; //assigning the color
                    Console.WriteLine("The color which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The number of eyes would determine blocked status");
                    int index2 = random.Next(numberOfEyes.Count); //random shape for blocked status
                    blockedStatus = numberOfEyes[index2];
                    Console.WriteLine("the number of Eyes should be Blocked: "+blockedStatus);
                    
                    foreach (var col in colors)
                    {
                      foreach (var numEye in numberOfEyes)
                      {
                        if(col == maliciousness & numEye == blockedStatus)
                        {
                            results.Add(col+numEye+"malicious_Blocked");
                        }
                        else if(col == maliciousness)
                        {
                            results.Add(col+numEye+"malicious_notBlocked");
                        }
                        else if(numEye == blockedStatus)
                        {
                            results.Add(col+numEye+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(col+numEye+"notmalicious_notBlocked");
                        }
                      }
                    }
                }
            //if the choice is number of eyes to be malicious    
            else 
                {
                    Console.WriteLine("It chose number of eyes to be malicious");
                    int index1 = random.Next(numberOfEyes.Count);
                    maliciousness = numberOfEyes[index1];
                    Console.WriteLine("The number of eyes which will be malicious: "+ maliciousness);
                    
                    Console.WriteLine("the color would determine the blocked status");
                    int index2 = random.Next(colors.Count); //random shape for blocked status
                    blockedStatus = colors[index2];
                    Console.WriteLine("the color that would be blocked: "+ blockedStatus);
                    
                    
                    foreach (var col in colors)
                    {
                      foreach (var numEye in numberOfEyes)
                      {
                        if(col == blockedStatus & numEye == maliciousness)
                        {
                            results.Add(col+numEye+"malicious_Blocked");
                        }
                        else if(col == blockedStatus)
                        {
                            results.Add(col+numEye+"notmalicious_Blocked");
                        }
                        else if(numEye == maliciousness)
                        {
                            results.Add(col+numEye+"malicious_notBlocked");
                        }
                        else 
                        {
                            results.Add(col+numEye+"notmalicious_notBlocked");
                        }
                      }
					}
				}	
            
            Console.WriteLine("Level 2 easy Mode Selected");
        
            return results;            
                    
        } 
        
        
    //for level 2 hard Mode
        //hard mode
        //color, no. of eyes, no. of antennas, no. arms (among these 4, we need to chose two for maliciousness and blocked status)
        //leave a scope for more atrributes to chose from (rather than only two all the time)
        
     //return type list of string
	    public List<string> Level2Hard()
        {
            List<string> results = new List<string>(){};
            string maliciousness = "";//for holding values of maliciousness
            string blockedStatus = "";
    
        //in the hard mode we have shape and color. we would randomly pick one of them for maliciousness and other one to be blocked status    
        //first we are gonna choose if it's the color or the shape for maliciousness. Then we are gonna choose the value (could be color or shape based on the value from the first randomization)
        //same thing for the blocked status...
        var random = new Random();
        int index = random.Next(choiceLevel2Hard.Count); //choosing for maliciousness
        Console.WriteLine("what did we choose to be malicious - "+choiceLevel2Hard[index]);    
            //choosing for maliciousness
        
        int indexComp = random.Next(choiceLevel2Hard.Count);
        while(index == indexComp)
        {
            indexComp = random.Next(choiceLevel2Hard.Count);
        }
        Console.WriteLine("what did we choose to be blocked - "+choiceLevel2Hard[indexComp]);
            
            //here we will implement all combinations of those 4 attributes -> 
            
            
            //if the color is malicious and eyes are blocked
            if(choiceLevel2Hard[index] == "color" & choiceLevel2Hard[indexComp] == "numberEyes")
                {   
                    Console.WriteLine("it chose color to be malicious");
                    int index1 = random.Next(colors.Count); //picking a random color for maliciousness
                    maliciousness = colors[index1]; //assigning the color
                    Console.WriteLine("The color which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The number of eyes would determine blocked status");
                    int index2 = random.Next(numberOfEyes.Count); //random shape for blocked status
                    blockedStatus = numberOfEyes[index2];
                    Console.WriteLine("the number of Eyes should be Blocked: "+blockedStatus);
                    
                    foreach (var col in colors)
                    {
                      foreach (var numEye in numberOfEyes)
                      {
                        if(col == maliciousness & numEye == blockedStatus)
                        {
                            results.Add(col+numEye+"malicious_Blocked");
                        }
                        else if(col == maliciousness)
                        {
                            results.Add(col+numEye+"malicious_notBlocked");
                        }
                        else if(numEye == blockedStatus)
                        {
                            results.Add(col+numEye+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(col+numEye+"notmalicious_notBlocked");
                        }
                      }
                    }
                }
                        //if the color is malicious and antennas are blocked
            else if(choiceLevel2Hard[index] == "color" & choiceLevel2Hard[indexComp] == "numberAntennas")
                {   
                    Console.WriteLine("it chose color to be malicious");
                    int index1 = random.Next(colors.Count); //picking a random color for maliciousness
                    maliciousness = colors[index1]; //assigning the color
                    Console.WriteLine("The color which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The number of Antennas would determine blocked status");
                    int index2 = random.Next(numberOfAntennas.Count); //random shape for blocked status
                    blockedStatus = numberOfAntennas[index2];
                    Console.WriteLine("the number of Antennas should be Blocked: "+blockedStatus);
                    
                    foreach (var col in colors)
                    {
                      foreach (var numAnt in numberOfAntennas)
                      {
                        if(col == maliciousness & numAnt == blockedStatus)
                        {
                            results.Add(col+numAnt+"malicious_Blocked");
                        }
                        else if(col == maliciousness)
                        {
                            results.Add(col+numAnt+"malicious_notBlocked");
                        }
                        else if(numAnt == blockedStatus)
                        {
                            results.Add(col+numAnt+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(col+numAnt+"notmalicious_notBlocked");
                        }
                      }
                    }
                }
            //if the color is malicious and arms are blocked
            else if(choiceLevel2Hard[index] == "color" & choiceLevel2Hard[indexComp] == "numberArms")
                {   
                    Console.WriteLine("it chose color to be malicious");
                    int index1 = random.Next(colors.Count); //picking a random color for maliciousness
                    maliciousness = colors[index1]; //assigning the color
                    Console.WriteLine("The color which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The number of Arms would determine blocked status");
                    int index2 = random.Next(numberOfArms.Count); //random shape for blocked status
                    blockedStatus = numberOfArms[index2];
                    Console.WriteLine("the number of Arms should be Blocked: "+blockedStatus);
                    
                    foreach (var col in colors)
                    {
                      foreach (var numArm in numberOfArms)
                      {
                        if(col == maliciousness & numArm == blockedStatus)
                        {
                            results.Add(col+numArm+"malicious_Blocked");
                        }
                        else if(col == maliciousness)
                        {
                            results.Add(col+numArm+"malicious_notBlocked");
                        }
                        else if(numArm == blockedStatus)
                        {
                            results.Add(col+numArm+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(col+numArm+"notmalicious_notBlocked");
                        }
                      }
                    }
                }
                
            //if the color is blocked and eyes are malicious
            else if(choiceLevel2Hard[index] == "numberEyes" & choiceLevel2Hard[indexComp] == "colors")
                {   
                    Console.WriteLine("it chose number of eyes to be malicious");
                    int index1 = random.Next(numberOfEyes.Count); //picking a random color for maliciousness
                    maliciousness = numberOfEyes[index1]; //assigning the color
                    Console.WriteLine("The number of eyes which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The color would determine blocked status");
                    int index2 = random.Next(colors.Count); //random shape for blocked status
                    blockedStatus = colors[index2];
                    Console.WriteLine("the colors should be Blocked: "+blockedStatus);
                    
                    foreach (var col in colors)
                    {
                      foreach (var numEye in numberOfEyes)
                      {
                        if(numEye == maliciousness & col == blockedStatus)
                        {
                            results.Add(numEye+col+"malicious_Blocked");
                        }
                        else if(numEye == maliciousness)
                        {
                            results.Add(numEye+col+"malicious_notBlocked");
                        }
                        else if(col == blockedStatus)
                        {
                            results.Add(numEye+col+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(numEye+col+"notmalicious_notBlocked");
                        }
                      }
                    }
                }

            
            //if the number of Antennas is blocked and eyes are malicious
            else if(choiceLevel2Hard[index] == "numberEyes" & choiceLevel2Hard[indexComp] == "numberAntennas")
                {   
                    Console.WriteLine("it chose number of Eyes to be malicious");
                    int index1 = random.Next(numberOfEyes.Count); //picking a random color for maliciousness
                    maliciousness = numberOfEyes[index1]; //assigning the color
                    Console.WriteLine("The number of Eyes which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The number of Antennas would determine blocked status");
                    int index2 = random.Next(numberOfAntennas.Count); //random shape for blocked status
                    blockedStatus = numberOfAntennas[index2];
                    Console.WriteLine("the colors should be Blocked: "+blockedStatus);
                    
                    foreach (var numEye in numberOfEyes)
                    {
                      foreach (var numAnt in numberOfAntennas)
                      {
                        if(numEye == maliciousness & numAnt == blockedStatus)
                        {
                            results.Add(numEye+numAnt+"malicious_Blocked");
                        }
                        else if(numEye == maliciousness)
                        {
                            results.Add(numEye+numAnt+"malicious_notBlocked");
                        }
                        else if(numAnt == blockedStatus)
                        {
                            results.Add(numEye+numAnt+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(numEye+numAnt+"notmalicious_notBlocked");
                        }
                      }
                    }
                }

            //if the number of Arms are blocked and eyes are malicious
            else if(choiceLevel2Hard[index] == "numberEyes" & choiceLevel2Hard[indexComp] == "numberArms")
                {   
                    Console.WriteLine("it chose number of eyes to be malicious");
                    int index1 = random.Next(numberOfEyes.Count); //picking a random no of eyes for maliciousness
                    maliciousness = numberOfEyes[index1]; //assigning the no
                    Console.WriteLine("The number of eyes which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The no of arms would determine blocked status");
                    int index2 = random.Next(numberOfArms.Count); //random shape for blocked status
                    blockedStatus = numberOfArms[index2];
                    Console.WriteLine("the no of arms should be Blocked: "+blockedStatus);
                    
                    foreach (var numEye in numberOfEyes)
                    {
                      foreach (var numArm in numberOfArms)
                      {
                        if(numEye == maliciousness & numArm == blockedStatus)
                        {
                            results.Add(numEye+numArm+"malicious_Blocked");
                        }
                        else if(numEye == maliciousness)
                        {
                            results.Add(numEye+numArm+"malicious_notBlocked");
                        }
                        else if(numArm == blockedStatus)
                        {
                            results.Add(numEye+numArm+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(numEye+numArm+"notmalicious_notBlocked");
                        }
                      }
                    }
                }
            

            //if the colors are blocked and antennas are malicious
            else if(choiceLevel2Hard[index] == "numberAntennas" & choiceLevel2Hard[indexComp] == "color")
                {   
                    Console.WriteLine("it chose number of Antennas to be malicious");
                    int index1 = random.Next(numberOfAntennas.Count); //picking a random no of eyes for maliciousness
                    maliciousness = numberOfAntennas[index1]; //assigning the no
                    Console.WriteLine("The number of antennas which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The color would determine blocked status");
                    int index2 = random.Next(colors.Count); //random shape for blocked status
                    blockedStatus = colors[index2];
                    Console.WriteLine("the color should be Blocked: "+blockedStatus);
                    
                    foreach (var numAnt in numberOfAntennas)
                    {
                      foreach (var col in colors)
                      {
                        if(numAnt == maliciousness & col == blockedStatus)
                        {
                            results.Add(numAnt+col+"malicious_Blocked");
                        }
                        else if(numAnt == maliciousness)
                        {
                            results.Add(numAnt+col+"malicious_notBlocked");
                        }
                        else if(col == blockedStatus)
                        {
                            results.Add(numAnt+col+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(numAnt+col+"notmalicious_notBlocked");
                        }
                      }
                    }
                }

            //if the number of eyes are blocked and no of antennas are malicious
            else if(choiceLevel2Hard[index] == "numberAntennas" & choiceLevel2Hard[indexComp] == "numberEyes")
                {   
                    Console.WriteLine("it chose number of Antennas to be malicious");
                    int index1 = random.Next(numberOfAntennas.Count); //picking a random no of eyes for maliciousness
                    maliciousness = numberOfAntennas[index1]; //assigning the no
                    Console.WriteLine("The number of antennas which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The no of eyes would determine blocked status");
                    int index2 = random.Next(numberOfEyes.Count); //random shape for blocked status
                    blockedStatus = numberOfEyes[index2];
                    Console.WriteLine("the no of eyes should be Blocked: "+blockedStatus);
                    
                    foreach (var numAnt in numberOfAntennas)
                    {
                      foreach (var numEye in numberOfEyes)
                      {
                        if(numAnt == maliciousness & numEye == blockedStatus)
                        {
                            results.Add(numAnt+numEye+"malicious_Blocked");
                        }
                        else if(numAnt == maliciousness)
                        {
                            results.Add(numAnt+numEye+"malicious_notBlocked");
                        }
                        else if(numEye == blockedStatus)
                        {
                            results.Add(numAnt+numEye+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(numAnt+numEye+"notmalicious_notBlocked");
                        }
                      }
                    }
                }            
            
            //if the number of Arms are blocked and no of antennas are malicious
            else if(choiceLevel2Hard[index] == "numberAntennas" & choiceLevel2Hard[indexComp] == "numberArms")
                {   
                    Console.WriteLine("it chose number of antennas to be malicious");
                    int index1 = random.Next(numberOfAntennas.Count); //picking a random no of eyes for maliciousness
                    maliciousness = numberOfAntennas[index1]; //assigning the no
                    Console.WriteLine("The number of antennas which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The no of arms would determine blocked status");
                    int index2 = random.Next(numberOfArms.Count); //random shape for blocked status
                    blockedStatus = numberOfArms[index2];
                    Console.WriteLine("the no of arms should be Blocked: "+blockedStatus);
                    
                    foreach (var numAnt in numberOfAntennas)
                    {
                      foreach (var numArm in numberOfArms)
                      {
                        if(numAnt == maliciousness & numArm == blockedStatus)
                        {
                            results.Add(numAnt+numArm+"malicious_Blocked");
                        }
                        else if(numAnt == maliciousness)
                        {
                            results.Add(numAnt+numArm+"malicious_notBlocked");
                        }
                        else if(numArm == blockedStatus)
                        {
                            results.Add(numAnt+numArm+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(numAnt+numArm+"notmalicious_notBlocked");
                        }
                      }
                    }
                }            
            
            
            //if the number of Arms are malicious and colors are blocked
            else if(choiceLevel2Hard[index] == "numberArms" & choiceLevel2Hard[indexComp] == "color")
                {   
                    Console.WriteLine("it chose number of arms to be malicious");
                    int index1 = random.Next(numberOfArms.Count); //picking a random no of eyes for maliciousness
                    maliciousness = numberOfArms[index1]; //assigning the no
                    Console.WriteLine("The number of arms which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The color would determine blocked status");
                    int index2 = random.Next(colors.Count); //random shape for blocked status
                    blockedStatus = colors[index2];
                    Console.WriteLine("the color should be Blocked: "+blockedStatus);
                    
                    foreach (var numArm in numberOfArms)
                    {
                      foreach (var col in colors)
                      {
                        if(numArm == maliciousness & col == blockedStatus)
                        {
                            results.Add(numArm+col+"malicious_Blocked");
                        }
                        else if(numArm == maliciousness)
                        {
                            results.Add(numArm+col+"malicious_notBlocked");
                        }
                        else if(col == blockedStatus)
                        {
                            results.Add(numArm+col+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(numArm+col+"notmalicious_notBlocked");
                        }
                      }
                    }
                }            


            //if the number of Arms are malicious and no of eyes are blocked
            else if(choiceLevel2Hard[index] == "numberArms" & choiceLevel2Hard[indexComp] == "numberEyes")
                {   
                    Console.WriteLine("it chose number of arms to be malicious");
                    int index1 = random.Next(numberOfArms.Count); //picking a random no of eyes for maliciousness
                    maliciousness = numberOfArms[index1]; //assigning the no
                    Console.WriteLine("The number of arms which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The no of eyes would determine blocked status");
                    int index2 = random.Next(numberOfEyes.Count); //random shape for blocked status
                    blockedStatus = numberOfEyes[index2];
                    Console.WriteLine("the no of eyes should be Blocked: "+blockedStatus);
                    
                    foreach (var numArm in numberOfArms)
                    {
                      foreach (var numEye in numberOfEyes)
                      {
                        if(numArm == maliciousness & numEye == blockedStatus)
                        {
                            results.Add(numArm+numEye+"malicious_Blocked");
                        }
                        else if(numArm == maliciousness)
                        {
                            results.Add(numArm+numEye+"malicious_notBlocked");
                        }
                        else if(numEye == blockedStatus)
                        {
                            results.Add(numArm+numEye+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(numArm+numEye+"notmalicious_notBlocked");
                        }
                      }
                    }
                }            


            //if the number of Arms are malicious and no of antennas are blocked
            //else if(choiceLevel12Hard[index] == "numberArms" & choiceLevel12Hard[indexComp] == "numberAntennas")
              
            else  
                {   
                    Console.WriteLine("it chose number of arms to be malicious");
                    int index1 = random.Next(numberOfArms.Count); //picking a random no of eyes for maliciousness
                    maliciousness = numberOfArms[index1]; //assigning the no
                    Console.WriteLine("The number of arms which should be malicious: "+ maliciousness);
                    
                    Console.WriteLine("The no of antennass would determine blocked status");
                    int index2 = random.Next(numberOfAntennas.Count); //random shape for blocked status
                    blockedStatus = numberOfAntennas[index2];
                    Console.WriteLine("the no of antennas should be Blocked: "+blockedStatus);
                    
                    foreach (var numAnt in numberOfAntennas)
                    {
                      foreach (var numArm in numberOfArms)
                      {
                        if(numArm == maliciousness & numAnt == blockedStatus)
                        {
                            results.Add(numArm+numAnt+"malicious_Blocked");
                        }
                        else if(numArm == maliciousness)
                        {
                            results.Add(numArm+numAnt+"malicious_notBlocked");
                        }
                        else if(numAnt == blockedStatus)
                        {
                            results.Add(numArm+numAnt+"notmalicious_Blocked");
                        }
                        else 
                        {
                            results.Add(numArm+numAnt+"notmalicious_notBlocked");
                        }
                      }
                    }
                }            
            
            Console.WriteLine("Level 2 hard Mode Selected");
        
            return results;            
                    
        }
    
    
    
  static void Main() {
        //Console.WriteLine("Hello World");
    var random = new Random(); //using for random number generator
    string level;
    string mode;
	Console.Write("Enter the level (1, 2 or 3): "); //take level from the users
	level = Console.ReadLine();
    
	Console.Write("Enter the mode (easy or hard): "); //Take mode from the users
	mode = Console.ReadLine();
	
	var p = new ExtractingRule();
	if(level == "1" & mode == "easy")
	    {
	      returnValue = p.Level1Easy();
	    }
	else if (level == "1" & mode == "hard")
	    {
	       returnValue = p.Level1Hard();
	    }
	else if (level == "2" & mode == "easy")
	    {
	        returnValue = p.Level2Easy();
	    }
	else if (level == "2" & mode == "hard")
	    {
	        returnValue = p.Level2Hard();
	    }

    foreach (var k in returnValue)
    {
        Console.WriteLine(k);
    }
  }
}
