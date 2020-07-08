# Decision trees
The purpose of this solution is to get the sum of all the decision tree results.

    Input:
      - 1000 Decimal variables: VAR_0 ... VAR_999
      - 50 Decision trees
        * Multilevel
        * Each level has a condition based on a variable
            Example:
              * VAR_56 < 0.5
              * VAR_475 > 544 and VAR_475 < 892
        * The result of a decision tree is a decimal number
            Example: 0.2319949
          
    Output:
      - SCORE = Sum of the decision tree results
