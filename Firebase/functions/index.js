const functions = require("firebase-functions");
const admin = require("firebase-admin");
const appOptions = JSON.parse(process.env.FIREBASE_CONFIG);
const app = admin.initializeApp(appOptions, "app");
const database = app.database();

var successHtml = "Success! You can now return back to the app."; // Change this to any html page you like
var errorHtml = "Something went wrong!"; // Change this to any html page you like


exports.saveAuthToken = functions.https.onRequest((request, response) => {
    var guid = request.query["state"];
    var code = request.query["code"];

    if (guid.length == 0 || code.length == 0 || !validateGUID(guid)) {
        response.send(errorHtml);
        return;
    }

    database.ref("authTokens/" + guid).set(code).then(res => {
        response.send(successHtml);
    }).catch(e => {
        response.send(errorHtml)
    });
});

exports.getAuthToken = functions.https.onRequest((request, response) => {
    var guid = request.query["state"];

    if (guid.length == 0 || !validateGUID(guid)) {
        response.send("");
        return;
    }

    database.ref("authTokens/" + guid).get().then(res => {
        response.send(res.val());
        database.ref("authTokens/" + guid).set(null);
    }).catch(e => {
        response.send("")
    });
});

function validateGUID(guid){
    return guid.match("[0-9A-Fa-f]{8}-?([0-9A-Fa-f]{4}-?){3}[0-9A-Fa-f]{12}").length > 0;
}
