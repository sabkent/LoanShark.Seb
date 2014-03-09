package com.loanshark.accountmanagment;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);        

        final Button applyCommand = (Button) findViewById(R.id.applyCommand);
        final EditText editFirstName = (EditText) findViewById(R.id.editFirstName);
        
        applyCommand.setOnClickListener(new View.OnClickListener() {
			
			@Override
			public void onClick(View v) {
				String amount = editFirstName.getText().toString();
				
			}
		});
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }
    
}
