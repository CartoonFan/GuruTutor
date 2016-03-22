//
//  Copyright 2016  Andrew M. Olney
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.


module GuruTutor.Naive
open System



///need step ordered or not
//type Solution

//Game is tutoring session; it contains KCs and user
//Player is student and tutor
//Deck is list of problems
//Deal is assign problem
//Hand is problem; is list of steps/cards
//Card are steps; steps may be ordered or unordered
//Steps have KC associated with them



type Description = Description of string
type Solution = Solution of string
type Mastery = Mastery of float
type Id = Id of string

type KnowledgeComponent = KnowledgeComponent of Description * Mastery

type User = Id * KnowledgeComponent list

type Scaffolding =
    | Hint of string
    | Prompt of string
    | Assertion of string

type Step = Step of Description * Solution * Scaffolding list * KnowledgeComponent list

type Steps =
    | StrictOrder of Step list
    ///In this case all steps are assumed to be equivalent
    | NoOrder of Step list
    | PreferredOrder of Step list
    | Sequence of Steps

type Problem = Problem of Description * Solution * Steps
type Problems = Problem list
type Session = { Problems:Problems; Users: User list }

type Activity =
    | Introduction
    | Lecture
    | Scaffolding
    | Closing

///Should type be a record or a function that returns a record?
///Includes both tutor initiative and tutor opportunistic?
type TutorReactive =
    | Pump of string
    | Encourage of string
    | Feedback of string



let ScaffoldPriority = [ Hint; Prompt; Assertion ]

let exProb1 = 
    Problem(
        Description("How do you make coffee?"),
        Solution("You make coffee by heating water and pouring it over coffee grounds"),
        StrictOrder(
            [
                Step(
                    Description("heat water"),
                    Solution("First you must heat water"),
                    [ 
                        Hint("Since coffee is mostly water, what should you do first?")
                        Prompt("First you should heat what?")
                        Prompt("What should you do to the water first?")
                        Assertion("You should heat the water first")
                    ],
                    [
                        KnowledgeComponent(
                            Description("coffee needs hot water kc"), 
                            Mastery(0.0 )
                        )
                    ]
                )
                Step(
                    Description("pour water"),
                    Solution("Second you must pour water over coffee grounds"),
                    [ 
                        Hint("Since coffee needs coffee grounds, what should you do next?")
                        Prompt("Second you should pour water over what?")
                        Prompt("What should you do with the hot water next?")
                        Assertion("You should pour hot water over coffee grounds")
                    ],
                    [
                        KnowledgeComponent(
                            Description("coffee needs coffee grounds kc"), 
                            Mastery(0.0)
                        )
                    ]
                )
            ])
        )
