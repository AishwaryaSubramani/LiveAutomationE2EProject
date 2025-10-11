package ninja.register;

import java.time.Duration;
import java.util.Date;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import org.testng.annotations.Test;

public class TC_RF_001 {

	@Test
	public void verifyRegisteringWithMandatoryFeilds() {

		WebDriver driver = new ChromeDriver();
		WebDriverWait wait = new WebDriverWait(driver, Duration.ofSeconds(10));

		try {
			driver.manage().window().maximize();
			driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(3));

			driver.get("https://tutorialsninja.com/demo/");

			driver.findElement(By.xpath("//span[text()='My Account']")).click();
			driver.findElement(By.linkText("Register")).click();

			driver.findElement(By.id("input-firstname")).sendKeys("Aish");
			driver.findElement(By.id("input-lastname")).sendKeys("Subramani");
			driver.findElement(By.id("input-email")).sendKeys(generateEmail());
			driver.findElement(By.id("input-telephone")).sendKeys("987654332");
			driver.findElement(By.id("input-password")).sendKeys("11111");
			driver.findElement(By.id("input-confirm")).sendKeys("11111");

			driver.findElement(By.name("agree")).click();
			driver.findElement(By.xpath("//input[@value='Continue']")).click();

			// ✅ Wait for the success message heading
			WebElement successHeading = wait
					.until(ExpectedConditions.visibilityOfElementLocated(By.xpath("//div[@id='content']/h1")));

			String expectedHeading = "Your Account Has Been Created!";
			Assert.assertEquals(successHeading.getText(), expectedHeading, "Account creation heading mismatch!");

			// ✅ Validate detailed success message
			String contentText = driver.findElement(By.id("content")).getText();
			Assert.assertTrue(contentText.contains("Congratulations! Your new account has been successfully created!"));
			Assert.assertTrue(contentText.contains("You can now take advantage of member privileges"));
			Assert.assertTrue(contentText.contains("If you have ANY questions"));
			Assert.assertTrue(contentText.contains("contact us"));

			// ✅ Continue to account page
			driver.findElement(By.xpath("//a[@class='btn btn-primary']")).click();

			// ✅ Wait and verify "Edit your account information" link is visible
			WebElement editAccountInfo = wait
					.until(ExpectedConditions.visibilityOfElementLocated(By.linkText("Edit your account information")));
			Assert.assertTrue(editAccountInfo.isDisplayed(), "Edit Account Information link not displayed!");

			// ✅ Optional: Verify logout link exists
			WebElement logoutLink = driver.findElement(By.linkText("Logout"));
			Assert.assertTrue(logoutLink.isDisplayed(), "Logout link not displayed!");

		} finally {
			driver.quit();
		}
	}

	public String generateEmail() {
		return new Date().toString().replaceAll(" ", "").replaceAll(":", "") + "@gmail.com";
	}

}
