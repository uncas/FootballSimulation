$here = Split-Path -Parent $MyInvocation.MyCommand.Path
. "$here\FootballSimulation.ps1"

# Requirements: In terms of input and probability distribution of results

Describe "GetMatchPredictions" {
    It "Identical teams even distribution" {
        $prediction = GetMatchPrediction
        $probability1 = $prediction.Probability1
        $probabilityX = $prediction.ProbabilityX
        $probability2 = $prediction.Probability2
        $probability1.should.be($probability2)
        $probabilityX.should.be(100-$probability1-$probability2)
    }
}