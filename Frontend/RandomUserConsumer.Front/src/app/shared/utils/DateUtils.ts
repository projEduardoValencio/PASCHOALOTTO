class DateUtils {
  static getAge(dateOfBirthString: string): number {
    const today = new Date();
    let dateOfBirth = new Date(dateOfBirthString);
    const age = today.getFullYear() - dateOfBirth.getFullYear();
    const m = today.getMonth() - dateOfBirth.getMonth();

    if (m < 0 || (m === 0 && today.getDate() < dateOfBirth.getDate())) {
      return age - 1;
    }

    return age;
  }

  static getDateFormated(date: string):string{
    return new Date(date).toLocaleDateString('pt-BR');
  }
}

export default DateUtils;
