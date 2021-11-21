from DAL.DB import DB


class DBWeather:

    dta = DB()

    def select_all_temp(self):
        return self.dta.execute_select_query()

    def select_temp(self, date):
        return self.dta.execute_select_query(params={'date': date})

    def delete_all_temp(self):
        return self.dta.delete_query()

    def post_temp(self, meteomedia, weather, pi, day, month, time):
        return self.dta.post_query(meteomedia, weather, pi, day, month, time)



