$debug = $True

function MatchResult {
    param ($team1Goals = 0, $team2Goals = 0)
    $this = "" | Select Team1Goals, Team2Goals
    $this.Team1Goals = $team1Goals
    $this.Team2Goals = $team2Goals
    return $this
}

function ResultProbability {
    param ($result, $probability)
    $this = "" | Select Result, Probability
    $this.Result = $result
    $this.Probability = $probability
    return $this
}

function MatchPrediction {
    param ($probability1 = 33, $probabilityX = 34, $probability2 = 33)
    $this = "" | Select Probability1, ProbabilityX, Probability2, ResultProbabilities
    $this.Probability1 = $probability1
    $this.ProbabilityX = $probabilityX
    $this.Probability2 = $probability2
    $this.ResultProbabilities = @()
    return $this
}

function GetTime {
    param ($seconds)
    return $seconds/60
}

function SimulateMatch {
    $pitchWidth = 21
    $pitchLength = 31
    $ballX = 11
    $ballY = 16
    $minutes = 0
    $timeStep = 30
    for ($seconds = 0; $seconds -le 90*60; $seconds += $timeStep) {
        if ($debug) {
            $time = GetTime $seconds
            Write-Host "After $time minutes the ball is in area ($ballX, $ballY)."
        }
    }
    
    return MatchResult
}

function GetMatchPrediction {
    $numberOfSimulations = 2
    $simulations = @()
    for ($simulationIndex = 0; $simulationIndex -lt $numberOfSimulations; $simulationIndex++) {
        $simulations += SimulateMatch
    }
    
#    $simulationResults = $simulations | group 
    
    $prediction = MatchPrediction
    $prediction.ResultProbabilities += ResultProbability (MatchResult 1 0) 0.1
    $prediction.ResultProbabilities += ResultProbability (MatchResult 0 1) 0.1
    return $prediction
}

function RunMatch {
    cls
    $result = SimulateMatch
    $team1Goals = $result.Team1Goals
    $team2Goals = $result.Team2Goals
    "Result: $team1Goals-$team2Goals"
}