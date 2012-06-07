$debug = $False

function MatchResult {
    param ($team1Goals = 0, $team2Goals = 0)
    $this = "" | Select Team1Goals, Team2Goals, Description
    $this.Team1Goals = $team1Goals
    $this.Team2Goals = $team2Goals
    $this.Description = "$team1Goals-$team2Goals"
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
    
    $team1Goals = Get-Random 5
    $team2Goals = Get-Random 5
    
    return MatchResult $team1Goals $team2Goals
}

function GetMatchPrediction {
    $numberOfSimulations = 1000
    $simulations = @{}
    for ($simulationIndex = 0; $simulationIndex -lt $numberOfSimulations; $simulationIndex++) {
        $simulationResult = SimulateMatch
        $key = $simulationResult.Description
        if (!($simulations.ContainsKey($key))) {
            $resultProbability = ResultProbability $simulationResult 0
            $simulations.Add($key, $resultProbability)
        }
        
        $item = $simulations.Get_Item($key)
        $item.Probability += 1/$numberOfSimulations
    }
    
    $prediction = MatchPrediction
    
    $simulations = $simulations.GetEnumerator() | Sort-Object Name
    
    $y = $simulations.GetEnumerator() | Select Value
    foreach ($x in $y) {
        $prediction.ResultProbabilities += $x.Value
    }

    foreach ($item in $prediction.ResultProbabilities) {
        Write-Host "Case:"
        Write-Host $item.Result
        Write-Host $item.Probability
    }
    
    return $prediction
}

function RunMatch {
    cls
    $result = SimulateMatch
    $team1Goals = $result.Team1Goals
    $team2Goals = $result.Team2Goals
    "Result: $team1Goals-$team2Goals"
}