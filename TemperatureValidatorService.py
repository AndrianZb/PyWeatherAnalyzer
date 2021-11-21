def precision_calculator(meteomedia, weather_dot_com_temp, pi_temp):
    precision_1 = ((meteomedia - pi_temp) / pi_temp) * 100
    precision_2 = ((weather_dot_com_temp - pi_temp) / pi_temp) * 100
    final_precision = abs(int(((precision_2 + precision_1) / 2)))

    if final_precision < 5:
        precision_status = "Excellent"
    elif final_precision < 10:
        precision_status = "Good"
    elif final_precision < 15:
        precision_status = "Average"
    elif final_precision < 20:
        precision_status = "Bad"
    else:
        precision_status = "Very bad"

    return precision_status, final_precision




