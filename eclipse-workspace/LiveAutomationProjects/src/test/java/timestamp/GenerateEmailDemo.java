package timestamp;

import java.util.Date;

public class GenerateEmailDemo {

	public static void main(String[] args) {
		
		Date date = new Date();
		String dateString= date.toString();
	    String nospaceDateString = dateString.replaceAll(" ", "");
	    String nospaceandnoColonDateString = nospaceDateString.replaceAll("\\:","");
		String emailwithTimestamp = nospaceandnoColonDateString+"gmail.com";
		System.out.println(emailwithTimestamp);
		
		
	}

}
