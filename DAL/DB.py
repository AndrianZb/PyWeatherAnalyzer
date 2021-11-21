import mysql.connector


class DB:

    def __init__(self):
        try:
            self.config_file = "my.conf"
            self.connex = mysql.connector.connect(option_files=self.config_file)
        except mysql.connector.Error as e:
            print(e)
            self.close()

    def execute_select_query(self, params=None):
        return_set = []
        cursor = self.connex.cursor(dictionary=True)
        if params is None:
            cursor.execute("SELECT * FROM weather")
        else:
            where_clause = " WHERE " + " AND ".join(['`' + k + '` = %s' for k in params.keys()])
            values = list(params.values())
            sql = "SELECT * FROM weather" + where_clause
            cursor.execute(sql, values)

        for x in cursor:
            return_set.append(x)
        cursor.close()
        return return_set

    def delete_query(self):
        cursor = self.connex.cursor(dictionary=True)
        cursor.execute("TRUNCATE TABLE weather")
        return "Database is now empty"

    def post_query(self, meteomedia, weather, pi, day, month, time):
        cursor = self.connex.cursor()

        sql = "INSERT INTO weather (e_weather_1, e_weather_2, pi, day, month, time) VALUES (%s, %s, %s, %s, %s, %s)"
        temp_tuple = (meteomedia, weather, pi, day, month, time)
        cursor.execute(sql, temp_tuple)
        self.connex.commit()
        return "Ok"




